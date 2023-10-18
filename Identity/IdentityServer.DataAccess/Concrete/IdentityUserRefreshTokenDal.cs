using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class IdentityUserRefreshTokenDal : MsSqlRepositoryBase<IdentityUserRefreshToken>, IIdentityUserRefreshTokenDal
    {
        public IdentityUserRefreshTokenDal(AuthDbContext context) : base(context)
        {
        }
    }
}
