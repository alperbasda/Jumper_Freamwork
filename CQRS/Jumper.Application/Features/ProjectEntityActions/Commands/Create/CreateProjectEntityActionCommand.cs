using Jumper.Domain.Enums;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Commands.Create;

public class CreateProjectEntityActionCommand : IRequest<CreateProjectEntityActionResponse>
{
    private Guid _id = Guid.NewGuid();
    public Guid Id => _id;

    public Guid ProjectEntityId { get; set; }

    public string Name { get; set; }

    public bool CacheEnabled { get; set; }

    public bool LogEnabled { get; set; }

    public EntityAction EntityAction { get; set; }

    public bool IsConstant { get; set; } = false;

    public List<Guid> RequestProperties { get; set; }

    public List<Guid> ResponseProperties { get; set; }
}
