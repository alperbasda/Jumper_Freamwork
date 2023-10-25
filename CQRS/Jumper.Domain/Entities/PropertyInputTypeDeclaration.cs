using Core.Persistence.Models;

namespace Jumper.Domain.Entities;

public class PropertyInputTypeDeclaration : Entity<Guid>
{
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Template { get; set; } = null!;
}
