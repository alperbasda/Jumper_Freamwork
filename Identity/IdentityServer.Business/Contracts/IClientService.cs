using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Client;

namespace IdentityServer.Business.Contracts
{
    public interface IClientService : IBaseService<Client, CreateClientRequest, UpdateClientRequest, ClientResponse>
    {
    }
}
