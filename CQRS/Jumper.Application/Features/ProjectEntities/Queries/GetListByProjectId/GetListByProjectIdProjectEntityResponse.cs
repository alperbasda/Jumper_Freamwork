using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;

public class GetListByProjectIdProjectEntityResponse
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationId { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public bool IsConstant { get; set; }

}
