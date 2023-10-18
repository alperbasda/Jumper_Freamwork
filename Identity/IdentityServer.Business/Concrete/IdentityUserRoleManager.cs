using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.UserRole;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class IdentityUserRoleManager : BaseService<IdentityUserRole, CreateIdentityUserRoleRequest, UpdateIdentityUserRoleRequest, IdentityUserRoleResponse>, IIdentityUserRoleService
    {
        public IdentityUserRoleManager(IIdentityUserRoleDal repository, IQueryableRepositoryBase<IdentityUserRole> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }
    }
}
