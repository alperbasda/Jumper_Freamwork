using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateSerilogSettings
{
    public class UpdateSerilogSettingsProjectDeclarationCommand: IRequest<UpdateSerilogSettingsProjectDeclarationResponse>
    {
        public Guid Id { get; set; }

        public SeriLogConfigurations SeriLogConfigurations { get; set; }

        public ProjectStatus ProjectStatus => ProjectStatus.Preparing;
    }
}
