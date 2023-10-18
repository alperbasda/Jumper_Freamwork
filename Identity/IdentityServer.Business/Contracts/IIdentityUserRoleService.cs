
using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.UserRole;

namespace IdentityServer.Business.Contracts
{
    public interface IIdentityUserRoleService : IBaseService<IdentityUserRole, CreateIdentityUserRoleRequest, UpdateIdentityUserRoleRequest, IdentityUserRoleResponse>
    {
    }
}
