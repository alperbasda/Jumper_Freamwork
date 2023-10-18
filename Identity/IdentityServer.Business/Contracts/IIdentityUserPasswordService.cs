using EntityBase.Poco.Responses;
using IdentityServer.Entities.Poco.UserPassword;

namespace IdentityServer.Business.Contracts
{
    public interface IIdentityUserPasswordService
    {
        Task<Response<MessageResponse>> CreateAsync(CreateIdentityUserPasswordRequest createIdentityUserPasswordRequest);

        Task<bool> CheckPasswordAsync(Guid ownerId,string password);
    }
}
