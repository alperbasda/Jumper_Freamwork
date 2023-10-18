using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.UserScopes;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class IdentityUserScopeManager : BaseService<IdentityUserScope, CreateIdentityUserScopeRequest, UpdateIdentityUserScopeRequest, IdentityUserScopeResponse>, IIdentityUserScopeService
    {
        public IdentityUserScopeManager(IIdentityUserScopeDal repository, IQueryableRepositoryBase<IdentityUserScope> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }
    }
}
