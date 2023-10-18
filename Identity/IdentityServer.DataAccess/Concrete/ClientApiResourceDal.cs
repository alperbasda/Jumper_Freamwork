using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class ClientApiResourceDal : MsSqlRepositoryBase<ClientApiResource>, IClientApiResourceDal
    {
        public ClientApiResourceDal(AuthDbContext context) : base(context)
        {
        }
    }
}
