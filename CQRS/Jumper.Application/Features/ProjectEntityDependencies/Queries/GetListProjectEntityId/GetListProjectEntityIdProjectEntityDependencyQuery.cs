using Core.Persistence.Models.Responses;
using Jumper.Application.Base;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityDependencies.Queries.GetListProjectEntityId;

public class GetListProjectEntityIdProjectEntityDependencyQuery : BaseDynamicQuery, IRequest<ListModel<GetListProjectEntityIdProjectEntityDependencyResponse>>
{
    public Guid ProjectDeclarationId { get; set; }
}
