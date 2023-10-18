using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class RoleScopeDal : MsSqlRepositoryBase<RoleScope>, IRoleScopeDal
    {
        public RoleScopeDal(AuthDbContext context) : base(context)
        {
        }
    }
}
