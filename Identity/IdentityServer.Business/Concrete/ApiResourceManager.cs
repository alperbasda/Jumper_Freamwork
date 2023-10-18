using AutoMapperAdapter;
using EntityBase.Enum;
using EntityBase.Poco.Responses;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.ApiResource;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;
using Tools.Hashing;

namespace IdentityServer.Business.Concrete
{
    public class ApiResourceManager : BaseService<ApiResource, CreateApiResourceRequest, UpdateApiResourceRequest, ApiResourceResponse>, IApiResourceService
    {
        public ApiResourceManager(IApiResourceDal repository, IQueryableRepositoryBase<ApiResource> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }

        public async override Task<Response<ApiResourceResponse>> Update(UpdateApiResourceRequest request)
        {
            var data = await base.GetAsync(request.Id);
            if (!data.IsSuccessful)
                return data;

            request.ApiSecret = data.Data.ApiSecret;
            request.ApiSecretSalt = data.Data.ApiSecretSalt;
            return await base.Update(request);
        }

        public async Task<Response<ApiResourceResponse>> UpdateApiSecret(UpdateApiResourceSecretRequest request)
        {
            var data = await base.Repository.GetAsync(w => w.Id == request.Id);
            if (data == null)
                return Response<ApiResourceResponse>.Fail(AuthMessageManager.Get((int)ResponseMessage.NotFound), 404);

            if (!HashingHelper.VerifyPasswordHash(request.OldSecret, data.ApiSecret, data.ApiSecretSalt))
            {
               return Response<ApiResourceResponse>.Fail(AuthMessageManager.Get((int)ResponseMessage.WrongOldKey), 404);
            }

            byte[] secret;
            byte[] salt;
            HashingHelper.CreatePasswordHash(request.NewSecret, out secret, out salt);
            data.ApiSecret = secret;
            data.ApiSecretSalt = salt;

            if (base.Repository.SetState(data, OperationType.Update) == null)
            {
                Response<ApiResourceResponse>.Fail(AuthMessageManager.Get((int)ResponseMessage.IntervalError), 500);
            }


            return Response<ApiResourceResponse>.Success(AutoMapperWrapper.Mapper.Map<ApiResourceResponse>(data), 201);
        }

        public async override Task<Response<ApiResourceResponse>> Create(CreateApiResourceRequest request)
        {
            byte[] secretHash, secretSalt;
            HashingHelper.CreatePasswordHash(request.ApiSecretStr, out secretHash, out secretSalt);
            request.ApiSecretSalt = secretSalt;
            request.ApiSecret = secretHash;
            var res = await base.Create(request);
            return res;
        }
    }
}
