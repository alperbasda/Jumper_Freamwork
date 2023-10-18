using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;

public class GetListByProjectIdProjectEntityResponse
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationId { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }

    public int PropertyCount { get; set; }

    public int ActionCount { get; set; }
}
