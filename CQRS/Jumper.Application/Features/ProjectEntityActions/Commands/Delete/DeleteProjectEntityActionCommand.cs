using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Commands.Delete;

public class DeleteProjectEntityActionCommand : IRequest<DeleteProjectEntityActionResponse>
{
    public Guid Id { get; set; }
}
