using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Queries.GetById;

public class GetByIdProjectEntityActionQuery : IRequest<GetByIdProjectEntityActionResponse>
{
    public Guid ProjectDeclarationRef { get; set; }

    public Guid Id { get; set; }

}
