
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityProperties.Queries.GetById;

public class GetByIdProjectEntityPropertyResponse
{
    public Guid Id { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public bool IsConstant { get; set; }

    public string Prefix { get; set; } = "";

    public string PropertyInputTypeCode { get; set; }
}
