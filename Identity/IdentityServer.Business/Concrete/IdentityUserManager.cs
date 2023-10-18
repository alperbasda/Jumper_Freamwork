using AutoMapperAdapter;
using EntityBase.Poco.Responses;
using ExpressionBuilder.Models;
using IdentityServer.Business.Constants;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.Extensions;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.Login;
using IdentityServer.Entities.Poco.User;
using IdentityServer.Entities.Poco.UserPassword;
using IdentityServer.Entities.Poco.UserRole;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;
using System.Text;


namespace IdentityServer.Business.Concrete
{
    public class IdentityUserManager : BaseService<IdentityUser, CreateIdentityUserRequest, UpdateIdentityUserRequest, IdentityUserResponse>, IIdentityUserService
    {
        IIdentityUserPasswordService _identityUserPasswordService;
        IQueryableRepositoryBase<IdentityUser> _queryable;
        IIdentityUserRoleService _identityUserRoleService;

        public IdentityUserManager(IIdentityUserDal repository, IQueryableRepositoryBase<IdentityUser> queryable, IIdentityUserPasswordService identityUserPasswordService, IUnitOfWork unitOfWork, IIdentityUserRoleService identityUserRoleService) : base(repository, queryable, unitOfWork)
        {
            _identityUserPasswordService = identityUserPasswordService;
            _identityUserRoleService = identityUserRoleService;
            _queryable = queryable;
        }

        public override async Task<Response<IdentityUserResponse>> Create(CreateIdentityUserRequest request)
        {
            var users = await base.Repository.GetListAsync(w =>
            w.ClientId == request.ClientId && 
            (w.NormalizedEmail == request.NormalizedEmail || w.PhoneNumber == request.PhoneNumber || w.NormalizedUserName == request.NormalizedUserName)
            );

            if (users != null && users.Count > 0)
            {
                return Response<IdentityUserResponse>.Fail(CompareUniqueProperties(users, request), 409);
            }
            var userCreateResponse = await base.Create(request);

            if (!userCreateResponse.IsSuccessful)
            {
                return userCreateResponse;
            }

            var passwordResponse = await _identityUserPasswordService.CreateAsync(
                    new CreateIdentityUserPasswordRequest
                    {
                        NewPassword = request.Password,
                        NewPasswordConfirm = request.PasswordConfirm,
                        OwnerId = userCreateResponse.Data.Id
                    });
            if (!passwordResponse.IsSuccessful)
            {
                return passwordResponse.FailConvert<IdentityUserResponse>();
            }

            var roleResponse = await _identityUserRoleService.Create(
                    new CreateIdentityUserRoleRequest
                    {
                        Id = Guid.NewGuid(),
                        RoleId = AuthConfig.DefaultUserRoleId,
                        IdentityUserId = userCreateResponse.Data.Id,
                        ExpiredDate = null,
                    });
            if (!roleResponse.IsSuccessful)
            {
                return roleResponse.FailConvert<IdentityUserResponse>();
            }

            return userCreateResponse;

        }

        public async Task<Response<IdentityUserResponse>> GetForLoginAsync(WebLoginRequest request)
        {

            var user = await _queryable.FirstOrDefault(FilterModel.Get(nameof(IdentityUser.NormalizedUserName), FilterOperator.Equals, request.UserName.ToLower()), new List<System.Linq.Expressions.Expression<Func<IdentityUser, object>>> { w => w.IdentityUserScopes });

            if (user == null || !user.IdentityUserScopes.Any(w => w.ExpiredDate == null || w.ExpiredDate > DateTime.Now))
                return Response<IdentityUserResponse>.Fail(ResponseMessage.NotFound.GetMessage(), 404);

            var passRes = await _identityUserPasswordService.CheckPasswordAsync(user.Id, request.Password);

            if (!passRes)
                return Response<IdentityUserResponse>.Fail(ResponseMessage.NotFound.GetMessage(), 404);

            return Response<IdentityUserResponse>.Success(AutoMapperWrapper.Mapper.Map<IdentityUserResponse>(user), 200);
        }

        private string CompareUniqueProperties(List<IdentityUser> users, CreateIdentityUserRequest request)
        {
            StringBuilder errorMessage = new StringBuilder();
            foreach (var user in users)
            {
                if (user.UserName == request.UserName)
                {
                    errorMessage.Append(AuthMessageManager.Get((int)ResponseMessage.UserNameAlreadyTaken));
                    errorMessage.Append(Environment.NewLine);
                }
                if (user.Email == request.Email)
                {
                    errorMessage.Append(AuthMessageManager.Get((int)ResponseMessage.MailAddressAlreadyTaken));
                    errorMessage.Append(Environment.NewLine);
                }
                if (user.PhoneNumber == request.PhoneNumber)
                {
                    errorMessage.Append(AuthMessageManager.Get((int)ResponseMessage.PhoneNumberAlreadyTaken));
                    errorMessage.Append(Environment.NewLine);
                }
            }

            return errorMessage.ToString();
        }

    }
}
