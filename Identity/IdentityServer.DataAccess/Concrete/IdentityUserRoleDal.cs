using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class IdentityUserRoleDal : MsSqlRepositoryBase<IdentityUserRole>, IIdentityUserRoleDal
    {
        public IdentityUserRoleDal(AuthDbContext context) : base(context)
        {
        }
    }
}
