using Core.Persistence.Models.Responses;
using Jumper.Application.Base.Dynamic;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectId;

public class GetListByProjectIdProjectEntityActionQuery :BaseDynamicQuery, IRequest<ListModel<GetListByProjectIdProjectEntityActionResponse>>
{
    public Guid ProjectDeclarationRef { get; set; }
}
