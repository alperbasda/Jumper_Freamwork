using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.ApiResource;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class ApiResourceScopeManager : BaseService<ApiResourceScope, CreateApiResourceScopeRequest, UpdateApiResourceScopeRequest, ApiResourceScopeResponse>, IApiResourceScopeService
    {
        public ApiResourceScopeManager(IApiResourceScopeDal repository, IQueryableRepositoryBase<ApiResourceScope> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }
    }
}
