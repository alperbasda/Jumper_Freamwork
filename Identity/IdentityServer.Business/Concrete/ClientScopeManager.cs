using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Client;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class ClientScopeManager : BaseService<ClientScope, CreateClientScopeRequest, UpdateClientScopeRequest, ClientScopeResponse>, IClientScopeService
    {
        public ClientScopeManager(IClientScopeDal repository, IQueryableRepositoryBase<ClientScope> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }
    }
}
