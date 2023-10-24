using Core.Persistence.Models;
using Jumper.Domain.Base;
using Jumper.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumper.Domain.Entities;

public class ProjectEntityProperty : Entity<Guid> , IConstantEntity
{
    public Guid ProjectEntityId { get; set; }

    public virtual ProjectEntity ProjectEntity { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public bool IsConstant { get; set; }

    /// <summary>
    /// Virtual abstract vb.
    /// </summary>
    public string Prefix { get; set; }

    /// <summary>
    /// Metod parametrelerin bulunup bulunmayacagını belirler. Bulunacak ise UI da hangi tipte gösterileceğini belirtir.
    /// </summary>
    public PropertyPocoType PropertyPocoType { get; set; } = PropertyPocoType.Input;

    [InverseProperty("ProjectEntityProperty")]
    public virtual ICollection<ProjectEntityActionProperty> Metods { get; set; }
}
