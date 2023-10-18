using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Commands.CreateFromDefinition;

public class CreateFromDefinitionProjectEntityCommand : IRequest<CreateFromDefinitionProjectEntityResponse>
{
    private Guid _id = Guid.NewGuid();
    public Guid Id => _id;

    public Guid? UserId { get; set; }

    public Guid ProjectDeclarationId { get; set; }

    public Guid EntityDefinitionId { get; set; }

    public DatabaseType DatabaseType { get; set; }
}
