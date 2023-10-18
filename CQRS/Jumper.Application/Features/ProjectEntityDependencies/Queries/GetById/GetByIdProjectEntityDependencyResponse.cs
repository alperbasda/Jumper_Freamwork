using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityDependencies.Queries.GetById;

public class GetByIdProjectEntityDependencyResponse
{
    public Guid Id { get; set; }

    public Guid DependedEntityId { get; set; }

    public string DependedEntityName { get; set; }

    public Guid DependsOnEntityId { get; set; }

    public string DependsOnEntityName { get; set; }

    public EntityDependencyType EntityDependencyType { get; set; }
}
