using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRelationalDatabaseSettings;

public class UpdateRelationalDatabaseSettingsProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public RelationalDatabaseConfiguration RelationalDatabaseConfiguration { get; set; }
}
