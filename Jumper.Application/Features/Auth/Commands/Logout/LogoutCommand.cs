using MediatR;

namespace Jumper.Application.Features.Auth.Commands.Logout;

public class LogoutCommand : INotification
{
    public string RefreshToken { get; set; }
}
