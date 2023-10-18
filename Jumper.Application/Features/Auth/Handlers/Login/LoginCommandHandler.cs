using Jumper.Application.Features.Auth.Commands.Login;
using Jumper.Application.Features.Auth.HttpClients;
using Jumper.Application.Features.Auth.Rules;
using Jumper.Domain.Configurations;
using MediatR;


namespace Jumper.Application.Features.Auth.Handlers.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    IIdentityServerClientService _identityServerClientService;
    JwtTokenOptions _jwtTokenOptions;
    AuthBusinessRules _authBusinessRules;

    public LoginCommandHandler(JwtTokenOptions jwtTokenOptions, IIdentityServerClientService identityServerClientService, AuthBusinessRules authBusinessRules)
    {
        _jwtTokenOptions = jwtTokenOptions;
        _identityServerClientService = identityServerClientService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        request.ClientSecret = _jwtTokenOptions.ClientSecret;
        request.ClientId = _jwtTokenOptions.ClientId;
        var res = await _identityServerClientService.CreateToken(request);
        _authBusinessRules.ThrowExceptionIfLoginFailed(res);

        return res.Data;
    }
}
