using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Commands.Update;

public class UpdateEntityDefinitionCommand : IRequest<UpdateEntityDefinitionResponse>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}
