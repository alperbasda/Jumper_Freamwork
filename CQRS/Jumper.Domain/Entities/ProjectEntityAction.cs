using Core.Persistence.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumper.Domain.Entities;

public class ProjectEntityAction : Entity<Guid>
{
    public Guid ProjectEntityId { get; set; }

    public virtual ProjectEntity ProjectEntity { get; set; }

    public string Name { get; set; }

    [InverseProperty("ProjectEntityAction")]
    public virtual ICollection<ProjectEntityActionProperty> Properties { get; set; }
}

