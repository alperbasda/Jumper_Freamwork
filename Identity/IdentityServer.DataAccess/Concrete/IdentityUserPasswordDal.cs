using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class IdentityUserPasswordDal : MsSqlRepositoryBase<IdentityUserPassword>, IIdentityUserPasswordDal
    {
        public IdentityUserPasswordDal(AuthDbContext context) : base(context)
        {
        }
    }
}
