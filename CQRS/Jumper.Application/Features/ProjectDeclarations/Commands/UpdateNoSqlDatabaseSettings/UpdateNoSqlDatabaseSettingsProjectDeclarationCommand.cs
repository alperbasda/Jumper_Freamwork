using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;
using MediatR;


namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateNoSqlDatabaseSettings;

public class UpdateNoSqlDatabaseSettingsProjectDeclarationCommand : IRequest<UpdateNoSqlDatabaseSettingsProjectDeclarationResponse>
{
    public Guid Id { get; set; }


    public NoSqlDatabaseConfiguration NoSqlDatabaseConfiguration { get; set; }

    ProjectStatus ProjectStatus => ProjectStatus.Preparing;

}
