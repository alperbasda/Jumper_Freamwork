using MediatR;

namespace Jumper.Application.Features.ProjectEntityActionProperties.Queries.GetById;

public class GetByIdProjectEntityActionPropertyQuery  : IRequest<GetByIdProjectEntityActionPropertyResponse>
{
    public Guid Id { get; set; }

    public Guid ProjectDeclarationRef { get; set; }
}


