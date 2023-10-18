using Core.Persistence.Models.Responses;
using Jumper.Application.Base.Dynamic;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityProperties.Queries.GetListByProjectEntityId;

public class GetListByProjectEntityIdProjectEntityPropertyQuery :BaseDynamicQuery, IRequest<ListModel<GetListByProjectEntityIdProjectEntityPropertyResponse>>
{
    public Guid ProjectDeclarationRef { get; set; }

    public Guid ProjectEntityId { get; set; }

}
