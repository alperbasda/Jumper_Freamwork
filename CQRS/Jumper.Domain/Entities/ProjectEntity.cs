using Core.Persistence.Models;
using Jumper.Domain.Base;
using Jumper.Domain.Enums;

namespace Jumper.Domain.Entities;

public class ProjectEntity : Entity<Guid>, IUserOwnedEntity, IConstantEntity
{
    public Guid UserId { get; set; }
    
    public Guid ProjectDeclarationId { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }

    public bool IsConstant { get; set; }

    public virtual ICollection<ProjectEntityDependency> Depended { get; set; }

    public virtual ICollection<ProjectEntityDependency> DependsOn { get; set; }

    public virtual ICollection<ProjectEntityProperty> Properties { get; set; }

    public virtual ICollection<ProjectEntityAction> ProjectEntityActions { get; set; }
}
