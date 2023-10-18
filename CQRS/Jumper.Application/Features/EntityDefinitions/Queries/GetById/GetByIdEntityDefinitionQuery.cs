using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Queries.GetById;

public class GetByIdEntityDefinitionQuery : IRequest<GetByIdEntityDefinitionResponse>
{
    public Guid Id { get; set; }

}
