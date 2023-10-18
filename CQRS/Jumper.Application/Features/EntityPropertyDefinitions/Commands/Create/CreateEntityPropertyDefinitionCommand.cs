
using MediatR;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Commands.Create;

public class CreateEntityPropertyDefinitionCommand : IRequest<CreateEntityPropertyDefinitionResponse>
{
    public Guid EntityDefinitionId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public bool IsConstants { get; set; } = false;
}
