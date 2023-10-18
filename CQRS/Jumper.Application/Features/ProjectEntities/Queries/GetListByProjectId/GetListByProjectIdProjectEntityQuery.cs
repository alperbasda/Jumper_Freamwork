using Core.Persistence.Models.Responses;
using Jumper.Application.Base;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;

public class GetListByProjectIdProjectEntityQuery : BaseDynamicQuery, IRequest<ListModel<GetListByProjectIdProjectEntityResponse>>
{
    public Guid ProjectDeclarationId { get; set; }
}
