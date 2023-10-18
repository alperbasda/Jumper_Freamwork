
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetById;

public class GetByIdProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool UseDatabase { get; set; }

    public bool UseCache { get; set; }

    public bool UseRabbitMq { get; set; }

    public bool UseSerilog { get; set; }

    public bool CreateApi { get; set; }

    public bool CreateUI { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public ProjectStatus ProjectStatus { get; set; }
}
