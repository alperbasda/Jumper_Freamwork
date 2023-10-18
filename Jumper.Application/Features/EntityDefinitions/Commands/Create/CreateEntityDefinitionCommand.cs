using Core.Application.Pipelines.Transaction;
using MediatR;


namespace Jumper.Application.Features.EntityDefinitions.Commands.Create
{
    public class CreateEntityDefinitionCommand : IRequest<CreateEntityDefinitionResponse> , ITransactionalRequest
    {
        public string Name { get; set; }
    }
}
