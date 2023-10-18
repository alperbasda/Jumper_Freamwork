using Jumper.Application.Features.Auth.Commands.Logout;
using Jumper.Application.Features.Auth.HttpClients;
using MediatR;

namespace Jumper.Application.Features.Auth.Handlers.Logout;

public class LogoutCommandHandler : INotificationHandler<LogoutCommand>
{
    IIdentityServerClientService _identityServerClientService;

    public LogoutCommandHandler(IIdentityServerClientService identityServerClientService)
    {
        _identityServerClientService = identityServerClientService;
    }

    public async Task Handle(LogoutCommand notification, CancellationToken cancellationToken)
    {
        await _identityServerClientService.RevokeRefreshToken(notification.RefreshToken);
    }
}
