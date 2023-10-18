using Jumper.Domain.Enums;
using MediatR;


namespace Jumper.Application.Features.ProjectEntityActionProperties.Commands.Create;

public class CreateProjectEntityActionPropertyCommand : IRequest<CreateProjectEntityActionPropertyResponse>
{
    private Guid _id = Guid.NewGuid();

    public Guid Id => _id;

    public Guid ProjectDeclarationRef { get; set; }

    public Guid ProjectEntityActionId { get; set; }

    public string Name { get; set; }

    public ActionPropertyType ActionPropertyType { get; set; }
}


