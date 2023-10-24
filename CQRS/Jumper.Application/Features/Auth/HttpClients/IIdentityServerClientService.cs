using Core.Persistence.Models.Responses;
using Jumper.Application.Features.Auth.Commands.Login;
using Jumper.Application.Features.Auth.Commands.RefreshToken;

namespace Jumper.Application.Features.Auth.HttpClients;

public interface IIdentityServerClientService
{
    Task<Response<LoginResponse>> CreateToken(LoginCommand request);

    Task<Response<RefreshTokenResponse>> RefreshToken(RefreshTokenCommand command);

    Task<Response<NoContent>> RevokeRefreshToken(string refreshToken);
}
