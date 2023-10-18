using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Commands.Delete;

public class DeleteProjectEntityCommand : IRequest<DeleteProjectEntityResponse>
{
    public Guid Id { get; set; }
}
