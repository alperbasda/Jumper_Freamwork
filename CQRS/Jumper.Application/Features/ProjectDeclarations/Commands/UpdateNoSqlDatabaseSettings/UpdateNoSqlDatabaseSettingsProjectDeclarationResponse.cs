using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateNoSqlDatabaseSettings;

public class UpdateNoSqlDatabaseSettingsProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public RelationalDatabaseConfiguration RelationalDatabaseConfiguration { get; set; }
}
