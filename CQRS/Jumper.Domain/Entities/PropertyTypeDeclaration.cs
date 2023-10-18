using Core.Persistence.Models;

namespace Jumper.Domain.Entities;

public class PropertyTypeDeclaration : Entity<Guid>
{
    public string Name { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

}
