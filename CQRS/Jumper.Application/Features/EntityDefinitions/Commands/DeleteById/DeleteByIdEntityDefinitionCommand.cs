using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Commands.DeleteById
{
    public class DeleteByIdEntityDefinitionCommand : IRequest<DeleteByIdEntityDefinitionResponse>
    {
        public Guid Id { get; set; }
    }
}
