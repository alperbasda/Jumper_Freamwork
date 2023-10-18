using AutoMapperAdapter;
using EntityBase.Poco.Responses;
using ExpressionBuilder.Models;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.ClientApiResource;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;
using System.Linq.Expressions;

namespace IdentityServer.Business.Concrete
{
    public class ClientApiResourceManager : BaseService<ClientApiResource, CreateClientApiResourceRequest, UpdateClientApiResourceRequest, ClientApiResourceResponse>, IClientApiResourceService
    {
        IQueryableRepositoryBase<ClientApiResource> _queryableRepositoryBase;
        public ClientApiResourceManager(IClientApiResourceDal repository, IQueryableRepositoryBase<ClientApiResource> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
            _queryableRepositoryBase = queryable;
        }
        public override async Task<Response<ClientApiResourceResponse>> Create(CreateClientApiResourceRequest request)
        {
            var res = await base.Create(request);
            if (!res.IsSuccessful)
            {
                return res;
            }
            var data = await _queryableRepositoryBase.List(FilterModel.Get(nameof(ClientApiResource.Id), FilterOperator.Equals, request.Id), new List<Expression<Func<ClientApiResource, object>>> { w => w.ApiResource, w => w.Client });
            return Response<ClientApiResourceResponse>.Success(AutoMapperWrapper.Mapper.Map<ClientApiResourceResponse>(data), 200);

        }

        public async override Task<Response<ClientApiResourceResponse>> Update(UpdateClientApiResourceRequest request)
        {
            var res = await base.Update(request);
            if (!res.IsSuccessful)
            {
                return res;
            }
            var data = await _queryableRepositoryBase.List(FilterModel.Get(nameof(ClientApiResource.Id), FilterOperator.Equals, request.Id), new List<Expression<Func<ClientApiResource, object>>> { w => w.ApiResource, w => w.Client });
            return Response<ClientApiResourceResponse>.Success(AutoMapperWrapper.Mapper.Map<ClientApiResourceResponse>(data), 200);

        }
    }
}
