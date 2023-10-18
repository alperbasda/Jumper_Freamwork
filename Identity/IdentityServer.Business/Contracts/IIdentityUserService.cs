using EntityBase.Poco.Responses;
using IdentityServer.Business.ServiceBase;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Login;
using IdentityServer.Entities.Poco.User;

namespace IdentityServer.Business.Contracts
{
    public interface IIdentityUserService : IBaseService<IdentityUser, CreateIdentityUserRequest, UpdateIdentityUserRequest, IdentityUserResponse>
    {
        Task<Response<IdentityUserResponse>> GetForLoginAsync(WebLoginRequest request);
    }
}
