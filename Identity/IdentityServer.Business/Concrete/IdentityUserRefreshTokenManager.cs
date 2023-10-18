using EntityBase.Enum;
using ExpressionBuilder.Models;
using IdentityServer.Business.Contracts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class IdentityUserRefreshTokenManager : IIdentityUserRefreshTokenService
    {
        IIdentityUserRefreshTokenDal _identityUserRefreshTokenDal;
        IQueryableRepositoryBase<IdentityUserRefreshToken> _queryableRepositoryBase;
        IUnitOfWork _unitOfWork;

        public IdentityUserRefreshTokenManager(IIdentityUserRefreshTokenDal identityUserRefreshTokenDal, IQueryableRepositoryBase<IdentityUserRefreshToken> queryableRepositoryBase, IUnitOfWork unitOfWork)
        {
            _identityUserRefreshTokenDal = identityUserRefreshTokenDal;
            _queryableRepositoryBase = queryableRepositoryBase;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(IdentityUserRefreshToken token)
        {
            _identityUserRefreshTokenDal.SetState(token, OperationType.Create);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(FilterModel filter)
        {
            var items = await _queryableRepositoryBase.List<IdentityUserRefreshToken>(filter);
            if (items.TotalItem > 0)
            {
                _identityUserRefreshTokenDal.SetState(items.Items, OperationType.Delete);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<IdentityUserRefreshToken> GetAsync(FilterModel filter)
        {
            return await _queryableRepositoryBase.FirstOrDefault(filter);
        }

        public async Task UpdateAsync(IdentityUserRefreshToken token)
        {
            _identityUserRefreshTokenDal.SetState(token, OperationType.Update);
            await _unitOfWork.CommitAsync();
        }
    }
}
