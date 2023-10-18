using MediatR;

namespace Jumper.Application.Features.ProjectEntityDependencies.Queries.GetById;

public class GetByIdProjectEntityDependencyQuery : IRequest<GetByIdProjectEntityDependencyResponse>
{
    public Guid Id { get; set; }
}
