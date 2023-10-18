
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntities.Queries.GetById;

public class GetByIdProjectEntityResponse
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationId { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }
}
