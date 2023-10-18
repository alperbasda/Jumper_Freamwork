
using MediatR;

namespace Jumper.Application.Features.ProjectEntityProperties.Commands.Delete;

public class DeleteProjectEntityPropertyCommand : IRequest<DeleteProjectEntityPropertyResponse>
{
    public Guid Id { get; set; }
}
