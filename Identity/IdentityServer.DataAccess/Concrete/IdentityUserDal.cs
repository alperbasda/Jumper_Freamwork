using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class IdentityUserDal : MsSqlRepositoryBase<IdentityUser>, IIdentityUserDal
    {
        public IdentityUserDal(AuthDbContext context) : base(context)
        {
        }
    }
}
