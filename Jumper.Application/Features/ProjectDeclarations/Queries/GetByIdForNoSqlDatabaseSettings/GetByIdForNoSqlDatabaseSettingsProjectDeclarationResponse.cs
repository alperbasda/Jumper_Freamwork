using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForNoSqlDatabaseSettings;

public class GetByIdForNoSqlDatabaseSettingsProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public NoSqlDatabaseConfiguration NoSqlDatabaseConfiguration { get; set; }
}
