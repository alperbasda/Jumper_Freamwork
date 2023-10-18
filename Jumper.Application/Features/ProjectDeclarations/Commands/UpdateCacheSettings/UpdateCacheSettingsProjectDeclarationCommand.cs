using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateCacheSettings;

public class UpdateCacheSettingsProjectDeclarationCommand : IRequest<UpdateCacheSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }

    public CacheConfiguration CacheConfiguration { get; set; }

    public ProjectStatus ProjectStatus { get; set; }

}
