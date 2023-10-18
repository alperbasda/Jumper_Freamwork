using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Client;
using IdentityServer.Entities.Poco.Token;

namespace IdentityServer.Business.Contracts
{
    public interface ITokenService
    {
        ClientTokenResponse CreateClientToken(ClientResponse client);

        UserTokenResponse CreateUserToken(IdentityUser user,string clientId);

    }
}
