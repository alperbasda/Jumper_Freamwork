using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class ClientDal : MsSqlRepositoryBase<Client>, IClientDal
    {
        public ClientDal(AuthDbContext context) : base(context)
        {
        }
    }
}
