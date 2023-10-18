using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class IdentityUserScopeDal : MsSqlRepositoryBase<IdentityUserScope>, IIdentityUserScopeDal
    {
        public IdentityUserScopeDal(AuthDbContext context) : base(context)
        {
        }
    }
}
