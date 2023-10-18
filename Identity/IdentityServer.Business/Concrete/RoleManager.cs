using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Role;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class RoleManager : BaseService<Role, CreateRoleRequest, UpdateRoleRequest, RoleResponse>, IRoleService
    {
        public RoleManager(IRoleDal repository, IQueryableRepositoryBase<Role> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }
    }
}
