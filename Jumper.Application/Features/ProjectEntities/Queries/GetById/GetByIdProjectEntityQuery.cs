
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Queries.GetById;

public class GetByIdProjectEntityQuery : IRequest<GetByIdProjectEntityResponse>
{
    public Guid Id { get; set; }
}
