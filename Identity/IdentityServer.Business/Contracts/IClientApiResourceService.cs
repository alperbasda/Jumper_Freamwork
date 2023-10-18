using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.ApiResource;
using IdentityServer.Entities.Poco.ClientApiResource;

namespace IdentityServer.Business.Contracts
{
    public interface IClientApiResourceService : IBaseService<ClientApiResource, CreateClientApiResourceRequest, UpdateClientApiResourceRequest, ClientApiResourceResponse>
    {
    }
}
