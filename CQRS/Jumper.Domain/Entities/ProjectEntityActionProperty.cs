using Core.Persistence.Models;
using Jumper.Domain.Enums;

namespace Jumper.Domain.Entities;

public class ProjectEntityActionProperty : Entity<Guid>
{
    public Guid ProjectEntityActionId { get; set; }

    public virtual ProjectEntityAction ProjectEntityAction { get; set; }

    public Guid? ProjectEntityPropertyId { get; set; }

    public virtual ProjectEntityProperty? ProjectEntityProperty { get; set; }

    public ActionPropertyType ActionPropertyType { get; set; }
}
