using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRelationalDatabaseSettings;

public class UpdateRelationalDatabaseSettingsProjectDeclarationCommand : IRequest<UpdateRelationalDatabaseSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }


    public RelationalDatabaseConfiguration RelationalDatabaseConfiguration { get; set; }

    ProjectStatus ProjectStatus => ProjectStatus.Preparing;

}
