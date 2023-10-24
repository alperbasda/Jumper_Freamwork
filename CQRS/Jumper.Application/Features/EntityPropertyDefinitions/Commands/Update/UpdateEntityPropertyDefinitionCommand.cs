using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Commands.Update;

public class UpdateEntityPropertyDefinitionCommand : IRequest<UpdateEntityPropertyDefinitionResponse>
{
    public Guid Id { get; set; }

    public Guid EntityDefinitionId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public PropertyPocoType PropertyPocoType { get; set; } = PropertyPocoType.Input;
}
