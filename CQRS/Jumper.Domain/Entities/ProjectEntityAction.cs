using Core.Persistence.Models;
using Jumper.Domain.Base;
using Jumper.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumper.Domain.Entities;

public class ProjectEntityAction : Entity<Guid>, IConstantEntity
{
    public Guid ProjectEntityId { get; set; }

    public virtual ProjectEntity ProjectEntity { get; set; }

    public string Name { get; set; }

    public bool CacheEnabled { get; set; }

    public bool LogEnabled { get; set; }

    public bool IsConstant { get; set; }

    public EntityAction EntityAction { get; set; }

    [InverseProperty("ProjectEntityAction")]
    public virtual ICollection<ProjectEntityActionProperty> Properties { get; set; }
}

