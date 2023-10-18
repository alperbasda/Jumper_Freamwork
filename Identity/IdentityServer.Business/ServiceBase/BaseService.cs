using AutoMapperAdapter;
using IdentityServer.Business.Concrete;
using IdentityServer.Entities.Enum;
using EntityBase.Db.Abstract;
using EntityBase.Enum;
using EntityBase.Poco.Responses;
using ExpressionBuilder.Models;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;
using System.Linq.Expressions;

namespace IdentityServer.Business.ServiceBase
{
    public class BaseService<TEntity, TCreateDto, TUpdateDto, TRes> : IBaseService<TEntity, TCreateDto, TUpdateDto, TRes>
        where TEntity : class, IEntity, new()
        where TCreateDto : class, new()
        where TUpdateDto : class, new()
        where TRes : class, new()
    {
        protected IQueryableRepositoryBase<TEntity> Queryable { get; private set; }

        protected IEntityRepositoryBase<TEntity> Repository { get; private set; }

        protected IUnitOfWork UnitOfWork { get; set; }

        public BaseService(IEntityRepositoryBase<TEntity> repository, IQueryableRepositoryBase<TEntity> queryable, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            Queryable = queryable;
            UnitOfWork = unitOfWork;
        }

        public virtual async Task<Response<TRes>> GetAsync(FilterModel filter, List<Expression<Func<TEntity, object>>> joinTables = null)
        {
            var data = await Queryable.FirstOrDefault<TRes>(filter, joinTables);

            if (data == null)
            {
                return Response<TRes>.Fail(AuthMessageManager.Get((int)ResponseMessage.NotFound), 404);
            }

            return Response<TRes>.Success(data, 200);
        }

        public Task<Response<TRes>> GetAsync(Guid id, List<Expression<Func<TEntity, object>>> joinTables = null)
        {
            return this.GetAsync(FilterModel.Get(nameof(IEntity.Id), FilterOperator.Equals, id), joinTables);
        }

        public virtual async Task<Response<IListModel<TRes>>> ListAsync(FilterModel filter, List<Expression<Func<TEntity, object>>> joinTables = null)
        {

            var listModel = await Queryable.List<TRes>(filter, joinTables);
            listModel.Filters = filter;
            return Response<IListModel<TRes>>.Success(listModel, 200);
        }

        public virtual async Task<Response<TRes>> Create(TCreateDto request)
        {
            var data = AutoMapperWrapper.Mapper.Map<TEntity>(request);
            Repository.SetState(data, OperationType.Create);
            if (await UnitOfWork.CommitAsync() <= 0)
                return Response<TRes>.Fail(AuthMessageManager.Get((int)ResponseMessage.IntervalError), 500);

            return Response<TRes>.Success(AutoMapperWrapper.Mapper.Map<TRes>(data), 201);
        }

        public virtual async Task<Response<MessageResponse>> Delete(FilterModel filter)
        {
            var res = await this.GetAsync(filter);

            if (!res.IsSuccessful || Repository.SetState(AutoMapperWrapper.Mapper.Map<TEntity>(res.Data), OperationType.Delete) == null)
            {
                return Response<MessageResponse>.Fail(AuthMessageManager.Get((int)ResponseMessage.NotFound), 404);
            }
            if (await UnitOfWork.CommitAsync() <= 0)
            {
                return Response<MessageResponse>.Fail(AuthMessageManager.Get((int)ResponseMessage.IntervalError), 500);
            }

            return Response<MessageResponse>.Success(new MessageResponse() { Message = AuthMessageManager.Get((int)ResponseMessage.Success) }, 200);
        }

        public virtual async Task<Response<TRes>> Update(TUpdateDto request)
        {
            TEntity data = AutoMapperWrapper.Mapper.Map<TEntity>(request);
            Repository.SetState(data, OperationType.Update);
            if (await UnitOfWork.CommitAsync() <= 0)
                return Response<TRes>.Fail(AuthMessageManager.Get((int)ResponseMessage.IntervalError), 500);

            return Response<TRes>.Success(AutoMapperWrapper.Mapper.Map<TRes>(data), 200);
        }

        public virtual async Task<Response<AnyResponseDetail<string>>> AnyAsync(IFilterModel filter)
        {
            var filterItems = String.Join(',', filter.Filters.Select(w => w.Value));
            var anyRes = new AnyResponseDetail<string>()
            {
                IsAny = await this.Queryable.AnyAsync(filter),
                Item = filterItems,
            };

            if (!anyRes.IsAny)
            {
                return Response<AnyResponseDetail<string>>.Fail(AuthMessageManager.Get((int)ResponseMessage.NotFound), 404);
            }
            return Response<AnyResponseDetail<string>>.Success(anyRes, 200);

        }

        public virtual async Task<Response<CountResponseDetail<string>>> CountAsync(IFilterModel filter)
        {
            var filterItems = String.Join(',', filter.Filters.Select(w => w.Value));
            var countRes = new CountResponseDetail<string>()
            {
                Count = await this.Queryable.CountAsync(filter),
                Item = filterItems,
            };

            return Response<CountResponseDetail<string>>.Success(countRes, 200);
        }

        public Task<Response<MessageResponse>> DeleteById(Guid id)
        {
            return this.Delete(FilterModel.Get(nameof(IEntity.Id), FilterOperator.Equals, id));
        }

    }
}
