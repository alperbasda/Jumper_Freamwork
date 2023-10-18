using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateInfo
{
    public class UpdateInfoProjectDeclarationResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

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
