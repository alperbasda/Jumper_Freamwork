using Jumper.Application.Features.Auth.Commands.RefreshToken;
using Jumper.Application.Features.Auth.HttpClients;
using Jumper.Application.Features.Auth.Rules;
using MediatR;

namespace Jumper.Application.Features.Auth.Handlers.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand,RefreshTokenResponse>
    {
        IIdentityServerClientService _identityServerClientService;
        AuthBusinessRules _authBusinessRules;

        public RefreshTokenCommandHandler(IIdentityServerClientService identityServerClientService, AuthBusinessRules authBusinessRules)
        {
            _identityServerClientService = identityServerClientService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshTokenResponse = await _identityServerClientService.RefreshToken(request.RefreshToken);
            
            _authBusinessRules.ThrowExceptionIfLoginFailed(refreshTokenResponse);
            
            return refreshTokenResponse.Data;
        }
    }
}
