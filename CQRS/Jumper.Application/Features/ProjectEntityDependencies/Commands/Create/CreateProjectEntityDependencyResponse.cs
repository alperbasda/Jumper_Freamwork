using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;

public class CreateProjectEntityDependencyResponse
{
    public Guid Id { get; set; }

    public Guid LeftEntityId { get; set; }

    public Guid RightEntityId { get; set; }

    public EntityDependencyType EntityDependencyType { get; set; }
}
