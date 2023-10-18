using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class RoleDal : MsSqlRepositoryBase<Role>, IRoleDal
    {
        public RoleDal(AuthDbContext context) : base(context)
        {
        }
    }
}
