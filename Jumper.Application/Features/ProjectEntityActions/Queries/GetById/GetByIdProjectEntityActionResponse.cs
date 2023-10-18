using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityActions.Queries.GetById;

public class GetByIdProjectEntityActionResponse
{
    public Guid Id { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string Name { get; set; }

    public bool CacheEnabled { get; set; }

    public bool LogEnabled { get; set; }

    public EntityAction EntityAction { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

}
