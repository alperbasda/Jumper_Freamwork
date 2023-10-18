using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRelationalDatabaseSettings;

public class GetByIdForRelationalDatabaseSettingsProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public RelationalDatabaseConfiguration RelationalDatabaseConfiguration { get; set; }
}
