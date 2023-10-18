using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Commands.Update;

public class UpdateProjectEntityCommand : IRequest<UpdateProjectEntityResponse>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }

    public Guid ProjectDeclarationId { get; set; }
}
