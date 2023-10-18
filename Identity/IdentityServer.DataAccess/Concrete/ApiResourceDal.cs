using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class ApiResourceDal : MsSqlRepositoryBase<ApiResource>, IApiResourceDal
    {
        public ApiResourceDal(AuthDbContext context) : base(context)
        {
        }
    }
}
