
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntities.Commands.Create;

public class CreateProjectEntityResponse
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationId { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; }

    public DatabaseType DatabaseType { get; set; }

    public bool IsConstant { get; set; }

}
