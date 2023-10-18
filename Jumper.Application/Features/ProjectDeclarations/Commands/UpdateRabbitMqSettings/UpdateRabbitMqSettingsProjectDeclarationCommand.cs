using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRabbitMqSettings
{
    public class UpdateRabbitMqSettingsProjectDeclarationCommand : IRequest<UpdateRabbitMqSettingsProjectDeclarationResponse>
    {
        public Guid Id { get; set; }

        public RabbitMqConfiguration RabbitMqConfiguration { get; set; }

        public ProjectStatus ProjectStatus => ProjectStatus.Preparing;
    }
}
