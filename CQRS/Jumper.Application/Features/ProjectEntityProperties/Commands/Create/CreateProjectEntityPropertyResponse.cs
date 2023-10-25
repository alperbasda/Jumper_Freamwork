
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityProperties.Commands.Create;

public class CreateProjectEntityPropertyResponse
{
    public Guid Id { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public string Prefix { get; set; } = "";

    public bool IsShowOnRelation { get; set; }

    public int Order { get; set; }
}
