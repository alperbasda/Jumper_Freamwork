using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Queries.GetById;

public class GetByIdProjectEntityActionQuery : IRequest<GetByIdProjectEntityActionResponse>
{
    public Guid Id { get; set; }

}
