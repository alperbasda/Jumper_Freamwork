using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateInfo
{
    public class UpdateInfoProjectDeclarationCommand : IRequest<UpdateInfoProjectDeclarationResponse>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool UseCache { get; set; }

        public bool UseRabbitMq { get; set; }

        public bool UseSerilog { get; set; }

        public bool CreateApi { get; set; }

        public bool CreateUI { get; set; }

        public ProjectStatus ProjectStatus => ProjectStatus.Preparing;
    }
}
