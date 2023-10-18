
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByLoggedUserId;

public class GetByLoggedUserIdProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedTime { get; set; }

	public DateTime? UpdatedTime { get; set; }

    public ProjectStatus ProjectStatus { get; set; }
}
