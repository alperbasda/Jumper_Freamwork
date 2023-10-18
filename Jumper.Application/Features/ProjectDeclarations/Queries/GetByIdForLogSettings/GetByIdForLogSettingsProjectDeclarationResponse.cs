
using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForLogSettings;

public class GetByIdForLogSettingsProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public SeriLogConfigurations? SeriLogConfigurations { get; set; }
}
