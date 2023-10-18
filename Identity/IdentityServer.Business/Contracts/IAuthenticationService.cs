using EntityBase.Poco.Responses;
using IdentityServer.Entities.Poco.Login;
using IdentityServer.Entities.Poco.Token;

namespace IdentityServer.Business.Contracts
{
    public interface IAuthenticationService
    {
        Task<Response<ClientTokenResponse>> CreateToken(ClientLoginRequest request);

        Task<Response<UserTokenResponse>> CreateToken(UserLoginRequest request);

        Task<Response<UserTokenResponse>> CreateToken(PhoneLoginRequest request);

        Task<Response<UserTokenResponse>> CreateTokenByRefreshToken(string refreshToken);

        Task<Response<NoContent>> RevokeRefreshToken(string refreshToken);

        Task<Response<NoContent>> RevokeRefreshToken(Guid userId);

    }
}
