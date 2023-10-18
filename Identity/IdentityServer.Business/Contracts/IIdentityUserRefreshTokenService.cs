using ExpressionBuilder.Models;
using IdentityServer.Entities.Db;

namespace IdentityServer.Business.Contracts
{
    public interface IIdentityUserRefreshTokenService
    {
        Task CreateAsync(IdentityUserRefreshToken token);

        Task UpdateAsync(IdentityUserRefreshToken token);

        Task<IdentityUserRefreshToken> GetAsync(FilterModel filter);

        Task DeleteAsync(FilterModel filter);
    }
}
