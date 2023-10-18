using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.AuthMessage;

namespace IdentityServer.Business.Contracts
{
    public interface IAuthMessageService : IBaseService<AuthMessage, CreateAuthMessageRequest, UpdateAuthMessageRequest, AuthMessageResponse>
    {
        
    }
}
