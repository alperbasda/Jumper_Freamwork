using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Context;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class AuthMessageDal : MsSqlRepositoryBase<AuthMessage>, IAuthMessageDal
    {
        public AuthMessageDal(MsSqlDbContext context) : base(context)
        {
        }
    }
}
