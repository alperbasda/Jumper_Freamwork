using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityActions.Commands.Create;

public class CreateProjectEntityActionResponse
{
    public Guid Id { get; set; }

    public Guid ProjectEntityId { get; set; }

    public string Name { get; set; }

    public bool CacheEnabled { get; set; }

    public bool LogEnabled { get; set; }

    public EntityAction EntityAction { get; set; }

    public DateTime CreatedTime { get; set; }
}
