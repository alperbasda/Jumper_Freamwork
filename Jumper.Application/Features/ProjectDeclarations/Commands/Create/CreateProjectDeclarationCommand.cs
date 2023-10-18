using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.Create
{
    public class CreateProjectDeclarationCommand : IRequest<CreateProjectDeclarationResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool UseDatabase { get; set; }

        public bool UseCache { get; set; }

        public bool UseRabbitMq { get; set; }

        public bool UseSerilog { get; set; }

        public bool CreateApi { get; set; }

        public bool CreateUI { get; set; }

    }
}
