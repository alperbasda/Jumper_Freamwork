
using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.UserScopes;

namespace IdentityServer.Business.Contracts
{
    public interface IIdentityUserScopeService : IBaseService<IdentityUserScope, CreateIdentityUserScopeRequest, UpdateIdentityUserScopeRequest, IdentityUserScopeResponse>
    {
    }
}
