using EntityBase.Db.Abstract;
using EntityBase.Poco.Responses;
using ExpressionBuilder.Models;
using System.Linq.Expressions;

namespace IdentityServer.Business.ServiceBase
{
    public interface IBaseService<TEntity, TCreateDto, TUpdateDto, TRes>
      where TEntity : class, IEntity, new()
      where TCreateDto : class, new()
      where TUpdateDto : class, new()
      where TRes : class
    {
        Task<Response<TRes>> GetAsync(FilterModel filter,List<Expression<Func<TEntity, object>>> joinTables = null);

        Task<Response<TRes>> GetAsync(Guid id, List<Expression<Func<TEntity, object>>> joinTables = null);

        Task<Response<IListModel<TRes>>> ListAsync(FilterModel filter, List<Expression<Func<TEntity, object>>> joinTables = null);

        Task<Response<TRes>> Create(TCreateDto request);

        Task<Response<TRes>> Update(TUpdateDto request);

        Task<Response<MessageResponse>> Delete(FilterModel filter);

        Task<Response<MessageResponse>> DeleteById(Guid id);

        Task<Response<AnyResponseDetail<string>>> AnyAsync(IFilterModel filter);

        Task<Response<CountResponseDetail<string>>> CountAsync(IFilterModel filter);
    }
}
