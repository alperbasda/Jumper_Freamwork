
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Commands.Create;

public class CreateEntityPropertyDefinitionResponse
{
    public Guid Id { get; set; }

    public Guid EntityDefinitionId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public DateTime CreatedTime { get; set; }

    public PropertyPocoType PropertyPocoType { get; set; } = PropertyPocoType.Input;
}
