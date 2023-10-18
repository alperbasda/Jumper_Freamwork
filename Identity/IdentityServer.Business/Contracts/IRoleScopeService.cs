using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.RoleScope;

namespace IdentityServer.Business.Contracts
{
    public interface IRoleScopeService : IBaseService<RoleScope, CreateRoleScopeRequest, UpdateRoleScopeRequest, RoleScopeResponse>
    {
    }
}
