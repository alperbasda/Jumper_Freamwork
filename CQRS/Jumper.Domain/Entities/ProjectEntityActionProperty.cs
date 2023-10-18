using Core.Persistence.Models;
using Jumper.Domain.Base;
using Jumper.Domain.Enums;

namespace Jumper.Domain.Entities;

public class ProjectEntityActionProperty : Entity<Guid>, IConstantEntity
{
    public Guid ProjectEntityActionId { get; set; }

    public virtual ProjectEntityAction ProjectEntityAction { get; set; }

    public Guid? ProjectEntityPropertyId { get; set; }

    public virtual ProjectEntityProperty? ProjectEntityProperty { get; set; }

    public ActionPropertyType ActionPropertyType { get; set; }

    public bool IsConstant { get; set; }
}
