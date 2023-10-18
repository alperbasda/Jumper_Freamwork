
using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForCacheSettings;

public class GetByIdForCacheSettingsProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public CacheConfiguration? CacheConfiguration { get; set; }

}
