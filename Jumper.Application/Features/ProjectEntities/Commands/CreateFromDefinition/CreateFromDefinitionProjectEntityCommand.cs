using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Commands.CreateFromDefinition;

public class CreateFromDefinitionProjectEntityCommand : IRequest<CreateFromDefinitionProjectEntityResponse>
{
    public Guid ProjectDeclarationId { get; set; }

    public Guid EntityDefinitionId { get; set; }

    public DatabaseType DatabaseType { get; set; }
}
