using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Commands.Create;

public class CreateProjectEntityCommand : IRequest<CreateProjectEntityResponse>
{
    private Guid _id = Guid.NewGuid();

    public Guid Id => _id;

    public Guid ProjectDeclarationId { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }

}
