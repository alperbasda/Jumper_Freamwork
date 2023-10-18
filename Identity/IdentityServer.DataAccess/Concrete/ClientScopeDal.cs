using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Context;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class ClientScopeDal : MsSqlRepositoryBase<ClientScope>,IClientScopeDal
    {
        public ClientScopeDal(MsSqlDbContext context) : base(context)
        {
        }
    }
}
