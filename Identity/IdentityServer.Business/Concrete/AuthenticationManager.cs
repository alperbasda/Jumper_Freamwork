using AutoMapperAdapter;
using EntityBase.Poco.Responses;
using ExpressionBuilder.Models;
using IdentityServer.Business.Constants;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.Extensions;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Login;
using IdentityServer.Entities.Poco.Token;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;
using Tools.Hashing;

namespace IdentityServer.Business.Concrete
{
    
    public class AuthenticationManager : IAuthenticationService
    {
        ITokenService _tokenService;
        IQueryableRepositoryBase<IdentityUser> _queryableRepositoryBase;
        IIdentityUserPasswordService _identityUserPasswordService;
        IIdentityUserRefreshTokenService _identityUserRefreshTokenService;
        IRoleScopeDal _roleScopeDal;
        IUnitOfWork _unitOfWork;
        public AuthenticationManager(ITokenService tokenService, IIdentityUserPasswordService identityUserPasswordService, IQueryableRepositoryBase<IdentityUser> queryableRepositoryBase, IRoleScopeDal roleScopeDal, IIdentityUserRefreshTokenService identityUserRefreshTokenService, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _identityUserPasswordService = identityUserPasswordService;
            _queryableRepositoryBase = queryableRepositoryBase;
            _roleScopeDal = roleScopeDal;
            _identityUserRefreshTokenService = identityUserRefreshTokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ClientTokenResponse>> CreateToken(ClientLoginRequest request)
        {

            var client = AuthConfig.Clients.SingleOrDefault(x => x.ClientId == request.ClientId);
            if (client == null || !HashingHelper.VerifyPasswordHash(request.ClientSecret, client.ClientSecret, client.ClientSecretSalt))
            {
                return Response<ClientTokenResponse>.Fail("Client Bilgileri Hatalı", 404);
            }

            var token = _tokenService.CreateClientToken(client);

            return Response<ClientTokenResponse>.Success(token, 200);
        }

        public async Task<Response<UserTokenResponse>> CreateToken(UserLoginRequest request)
        {
            var user = await GetUserWithIncludes(FilterModel.Get(nameof(IdentityUser.NormalizedUserName), FilterOperator.Equals, request.UserName.ToLower()));

            if (user == null ||
                !await _identityUserPasswordService.CheckPasswordAsync(user.Id, request.Password) ||
                !await FillAllScopesForUserIfClientExists(user, request.ClientId, request.ClientSecret)
                )
            {
                return Response<UserTokenResponse>.Fail("Kullanıcı Adı veya Şifre Hatalı", 404);
            }

            var token = _tokenService.CreateUserToken(user, request.ClientId);

            var refreshToken = await _identityUserRefreshTokenService.GetAsync(FilterModel.Get(nameof(IdentityUserRefreshToken.OwnerId), FilterOperator.Equals, user.Id));
            if (refreshToken == null)
            {
                await _identityUserRefreshTokenService.CreateAsync(
                    new IdentityUserRefreshToken { Id = Guid.NewGuid(), OwnerId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration, ClientId = request.ClientId });
            }
            else
            {
                refreshToken.Code = token.RefreshToken;
                refreshToken.Expiration = token.RefreshTokenExpiration;
                await _identityUserRefreshTokenService.UpdateAsync(refreshToken);
            }
            return Response<UserTokenResponse>.Success(token, 200);
        }

        public async Task<Response<UserTokenResponse>> CreateToken(PhoneLoginRequest request)
        {
            var user = await GetUserWithIncludes(FilterModel.Get(nameof(IdentityUser.NormalizedUserName), FilterOperator.Equals, request.Target.ToLower()));

            if (user == null ||
                !await FillAllScopesForUserIfClientExists(user, request.ClientId, request.ClientSecret)
                )
            {
                return Response<UserTokenResponse>.Fail("Kullanıcı Adı veya Şifre Hatalı", 404);
            }

            var token = _tokenService.CreateUserToken(user, request.ClientId);

            var refreshToken = await _identityUserRefreshTokenService.GetAsync(FilterModel.Get(nameof(IdentityUserRefreshToken.OwnerId), FilterOperator.Equals, user.Id));
            if (refreshToken == null)
            {
                await _identityUserRefreshTokenService.CreateAsync(
                    new IdentityUserRefreshToken { Id = Guid.NewGuid(), OwnerId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration, ClientId = request.ClientId });
            }
            else
            {
                refreshToken.Code = token.RefreshToken;
                refreshToken.Expiration = token.RefreshTokenExpiration;
                await _identityUserRefreshTokenService.UpdateAsync(refreshToken);
            }
            return Response<UserTokenResponse>.Success(token, 200);
        }

        public async Task<Response<UserTokenResponse>> CreateTokenByRefreshToken(string refreshToken)
        {
            var filters = FilterModel.Get(nameof(IdentityUserRefreshToken.Code), FilterOperator.Equals, refreshToken);
            filters.Filters.Add(FilterItem.Get(nameof(IdentityUserRefreshToken.Expiration), FilterOperator.GreaterThanOrEqual, DateTime.Now));

            var refToken = await _identityUserRefreshTokenService.GetAsync(filters);
            if (refToken == null)
            {
                return Response<UserTokenResponse>.Fail("Refresh Token Bulunamadı.", 404);
            }

            var user = await GetUserWithIncludes(FilterModel.Get(nameof(IdentityUser.Id), FilterOperator.Equals, refToken.OwnerId));

            if (
                user == null ||
                refToken.OwnerId != user.Id ||
                !await FillAllScopesForUserIfClientExists(user, refToken.ClientId, null)
                )
            {
                return Response<UserTokenResponse>.Fail("Kullanıcı Adı veya Şifre Hatalı", 404);
            }

            var token = _tokenService.CreateUserToken(user, refToken.ClientId);

            refToken.Code = token.RefreshToken;
            refToken.Expiration = token.RefreshTokenExpiration;

            await _identityUserRefreshTokenService.UpdateAsync(refToken);

            await _unitOfWork.CommitAsync();
            return Response<UserTokenResponse>.Success(token, 200);
        }

        public async Task<Response<NoContent>> RevokeRefreshToken(string refreshToken)
        {
            await _identityUserRefreshTokenService.DeleteAsync(FilterModel.Get(nameof(IdentityUserRefreshToken.Code), FilterOperator.Equals, refreshToken));

            return Response<NoContent>.Success(ResponseMessage.Success.GetMessage(), 200);
        }

        public async Task<Response<NoContent>> RevokeRefreshToken(Guid userId)
        {
            await _identityUserRefreshTokenService.DeleteAsync(FilterModel.Get(nameof(IdentityUserRefreshToken.OwnerId), FilterOperator.Equals, userId));

            return Response<NoContent>.Success(ResponseMessage.Success.GetMessage(), 200);
        }



        private async Task<bool> FillAllScopesForUserIfClientExists(IdentityUser user, string clientId, string? clientSecret)
        {
            var client = AuthConfig.Clients.SingleOrDefault(x => x.ClientId == clientId);
            if (client == null)
            {
                return false;
            }
            //Refresh tokenden gelen isteklerde clientsecret gelmez o yuzden böyle
            else if(!string.IsNullOrEmpty(clientSecret) && !HashingHelper.VerifyPasswordHash(clientSecret, client.ClientSecret, client.ClientSecretSalt))
            {
                return false;

            }

            user.IdentityUserScopes = user.IdentityUserScopes.Where(w => w.ExpiredDate == null || w.ExpiredDate > DateTime.Now).ToList();

            client.ClientScopes.Where(w => w.ExpiredDate == null || w.ExpiredDate > DateTime.Now).Select(w => new IdentityUserScope
            {
                CreateTime = w.CreateTime,
                UpdateTime = w.UpdateTime,
                ExpiredDate = w.ExpiredDate,
                OwnerId = user.Id,
                Scope = w.Scope,
                Id = w.Id
            }).ToList().ForEach(x => user.IdentityUserScopes.Add(x));

            if (user.IdentityUserRoles.Any())
            {
                var allRoles = user.IdentityUserRoles.Select(w => w.RoleId).ToList();
                var roleScopes = await _roleScopeDal.GetListAsync(w => allRoles.Contains(w.OwnerId));
                roleScopes.Where(w => w.ExpiredDate == null || w.ExpiredDate > DateTime.Now).Select(w => new IdentityUserScope
                {
                    CreateTime = w.CreateTime,
                    UpdateTime = w.UpdateTime,
                    ExpiredDate = w.ExpiredDate,
                    OwnerId = user.Id,
                    Scope = w.Scope,
                    Id = w.Id
                }).ToList()
                .ForEach(w => user.IdentityUserScopes.Add(w));
            }

            return true;
        }

        private async Task<IdentityUser?> GetUserWithIncludes(FilterModel model)
        {
            return await _queryableRepositoryBase.FirstOrDefault(model,
                              new List<System.Linq.Expressions.Expression<Func<IdentityUser, object>>> { w => w.IdentityUserScopes, w => w.IdentityUserRoles });
        }


    }
}
