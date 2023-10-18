using MediatR;

namespace Jumper.Application.Features.ProjectEntityActionProperties.Commands.Delete;

public class DeleteProjectEntityActionPropertyCommand : IRequest<DeleteProjectEntityActionPropertyResponse>
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationId { get; set; }

}

