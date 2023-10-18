using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectId;

public class GetListByProjectIdProjectEntityActionResponse
{
    public Guid Id { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string Name { get; set; }

    public bool CacheEnabled { get; set; }

    public bool LogEnabled { get; set; }

    public EntityAction EntityAction { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public List<> Properties { get; set; }
}
