
using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Role;

namespace IdentityServer.Business.Contracts
{
    public interface IRoleService : IBaseService<Role, CreateRoleRequest, UpdateRoleRequest, RoleResponse>
    {
    }
}
