
namespace Jumper.Application.Features.EntityDefinitions.Commands.Update;

public class UpdateEntityDefinitionResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }
}
