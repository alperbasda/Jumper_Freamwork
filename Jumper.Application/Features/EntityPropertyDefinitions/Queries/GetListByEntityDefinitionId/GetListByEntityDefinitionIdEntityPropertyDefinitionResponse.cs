namespace Jumper.Application.Features.EntityPropertyDefinitions.Queries.GetListByEntityDefinitionId;

public class GetListByEntityDefinitionIdEntityPropertyDefinitionResponse
{
    public Guid Id { get; set; }

    public Guid EntityDefinitionId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

}
