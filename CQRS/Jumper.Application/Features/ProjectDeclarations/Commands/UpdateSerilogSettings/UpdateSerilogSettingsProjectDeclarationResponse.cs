using Jumper.Domain.MongoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateSerilogSettings
{
    public class UpdateSerilogSettingsProjectDeclarationResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool UseSerilog { get; set; }

        public SeriLogConfigurations? SeriLogConfigurations { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }
    }
}
