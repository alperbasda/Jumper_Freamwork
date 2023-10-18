using Jumper.Domain.MongoEntities;


namespace Jumper.Application.Features.EntityDefinitions.Queries.GetListDynamic;

public class GetListDynamicEntityDefinitionQueryResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }
}
