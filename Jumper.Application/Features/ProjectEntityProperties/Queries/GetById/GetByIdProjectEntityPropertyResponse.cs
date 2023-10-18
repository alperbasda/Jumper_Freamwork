
namespace Jumper.Application.Features.ProjectEntityProperties.Queries.GetById;

public class GetByIdProjectEntityPropertyResponse
{
    public Guid Id { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }
}
