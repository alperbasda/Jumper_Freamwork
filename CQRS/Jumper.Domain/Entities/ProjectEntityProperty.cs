using Core.Persistence.Models;
using Jumper.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumper.Domain.Entities;

public class ProjectEntityProperty : Entity<Guid>, IConstantEntity
{
    public Guid ProjectEntityId { get; set; }

    public virtual ProjectEntity ProjectEntity { get; set; }

    public string PropertyTypeCode { get; set; }

    public string PropertyInputTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public bool IsConstant { get; set; }

    /// <summary>
    /// Virtual abstract vb.
    /// </summary>
    public string Prefix { get; set; }

    [InverseProperty("ProjectEntityProperty")]
    public virtual ICollection<ProjectEntityActionProperty> Metods { get; set; }

}
