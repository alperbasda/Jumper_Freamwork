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

    /// <summary>
    /// İlişkili bir tablo için gösterilecek değerin bu kolon oldugunu belirtir.
    /// </summary>
    public bool IsShowOnRelation { get; set; }

    public int Order { get; set; }

    [InverseProperty("ProjectEntityProperty")]
    public virtual ICollection<ProjectEntityActionProperty> Metods { get; set; }

}
