using EntityBase.Poco.Responses;
using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.ApiResource;

namespace IdentityServer.Business.Contracts
{
    public interface IApiResourceService : IBaseService<ApiResource, CreateApiResourceRequest, UpdateApiResourceRequest, ApiResourceResponse>
    {
        Task<Response<ApiResourceResponse>> UpdateApiSecret(UpdateApiResourceSecretRequest request);
    }
}
