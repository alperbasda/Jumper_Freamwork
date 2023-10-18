using Core.Persistence.Models.Responses;
using Jumper.Application.Base.Dynamic;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectEntityId;

public class GetListByProjectEntityIdProjectEntityActionQuery : BaseDynamicQuery, IRequest<ListModel<GetListByProjectEntityIdProjectEntityActionResponse>>
{
    public Guid ProjectDeclarationRef { get; set; }

    public Guid ProjectEntityId { get; set; }
}
