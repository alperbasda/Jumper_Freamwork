using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.ApiResource;

namespace IdentityServer.Business.Contracts
{
    public interface IApiResourceScopeService : IBaseService<ApiResourceScope, CreateApiResourceScopeRequest, UpdateApiResourceScopeRequest, ApiResourceScopeResponse>
    {
    }
}
