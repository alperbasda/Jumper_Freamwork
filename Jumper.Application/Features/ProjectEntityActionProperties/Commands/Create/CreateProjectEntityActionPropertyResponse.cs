using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityActionProperties.Commands.Create;

public class CreateProjectEntityActionPropertyResponse
{
    public Guid ProjectDeclarationRef { get; set; }

    public Guid ProjectEntityActionId { get; set; }

    public string Name { get; set; }

    public ActionPropertyType ActionPropertyType { get; set; }
}
