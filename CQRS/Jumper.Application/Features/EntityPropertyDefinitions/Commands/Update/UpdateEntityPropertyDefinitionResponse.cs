using Jumper.Domain.Enums;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Commands.Update;

public class UpdateEntityPropertyDefinitionResponse
{
    public Guid Id { get; set; }

    public Guid EntityDefinitionId { get; set; }

    public string EntityDefinitionName { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public string PropertyInputTypeCode { get; set; }
}
