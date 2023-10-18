
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntities.Commands.Update;

public class UpdateProjectEntityResponse
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationId { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }
}
