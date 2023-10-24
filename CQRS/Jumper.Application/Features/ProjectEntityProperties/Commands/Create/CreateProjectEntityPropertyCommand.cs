
using MediatR;

namespace Jumper.Application.Features.ProjectEntityProperties.Commands.Create;

public class CreateProjectEntityPropertyCommand : IRequest<CreateProjectEntityPropertyResponse>
{
    private Guid _id = Guid.NewGuid();
    public Guid Id => _id;

    public Guid ProjectEntityId { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public bool IsConstant { get; set; } = false;

    public string Prefix { get; set; } = "";
}
