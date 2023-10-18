using Core.Persistence.Models;
using Jumper.Domain.Enums;

namespace Jumper.Domain.Entities;

public class ProjectEntityDependency : Entity<Guid>
{
    public Guid ProjectDeclarationId { get; set; }

    public Guid? DependsOnId { get; set; }

    public virtual ProjectEntity DependsOnEntity { get; set; }

    public Guid? DependedId { get; set; }

    public virtual ProjectEntity DependedEntity { get; set; }

    public EntityDependencyType EntityDependencyType { get; set; }
}
