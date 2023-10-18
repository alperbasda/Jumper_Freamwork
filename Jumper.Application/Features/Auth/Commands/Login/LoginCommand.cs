using MediatR;

namespace Jumper.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }
}
