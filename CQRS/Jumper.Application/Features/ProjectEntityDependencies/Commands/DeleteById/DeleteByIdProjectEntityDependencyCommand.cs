using MediatR;

namespace Jumper.Application.Features.ProjectEntityDependencies.Commands.DeleteById;

public class DeleteByIdProjectEntityDependencyCommand : IRequest<DeleteByIdProjectEntityDependencyResponse>
{
    public Guid Id { get; set; }
}
