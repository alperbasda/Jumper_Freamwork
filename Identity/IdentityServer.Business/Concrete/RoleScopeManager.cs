using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.RoleScope;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class RoleScopeManager : BaseService<RoleScope, CreateRoleScopeRequest, UpdateRoleScopeRequest, RoleScopeResponse>, IRoleScopeService
    {
        public RoleScopeManager(IRoleScopeDal repository, IQueryableRepositoryBase<RoleScope> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }
    }
}

