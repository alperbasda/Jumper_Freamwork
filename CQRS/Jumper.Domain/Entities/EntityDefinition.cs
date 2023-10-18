using Core.Persistence.Models;

namespace Jumper.Domain.Entities;

public class EntityDefinition : Entity<Guid>, IUserOwnedEntity
{
    public Guid UserId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<EntityPropertyDefinition> EntityPropertyDefinitions { get; set; }

}
