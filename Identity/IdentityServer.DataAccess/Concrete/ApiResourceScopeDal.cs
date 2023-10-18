using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.Repository;

namespace IdentityServer.DataAccess.Concrete
{
    public class ApiResourceScopeDal : MsSqlRepositoryBase<ApiResourceScope>, IApiResourceScopeDal
    {
        public ApiResourceScopeDal(AuthDbContext context) : base(context)
        {
        }
    }
}
