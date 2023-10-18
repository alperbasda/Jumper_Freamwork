using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityDependencies.Queries.GetListProjectEntityId;

public class GetListProjectEntityIdProjectEntityDependencyResponse
{
    public Guid Id { get; set; }

    public Guid LeftEntityId { get; set; }

    public string DependedEntityName { get; set; }

    public Guid RightEntityId { get; set; }

    public string DependsOnEntityName { get; set; }

    public EntityDependencyType EntityDependencyType { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }
}
