namespace Jumper.Application.Features.ProjectEntityActionProperties.Queries.GetById;

public class GetByIdProjectEntityActionPropertyResponse
{
    public Guid ProjectDeclarationRef { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }
}
