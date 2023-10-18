using Core.Persistence.Models.Responses;
using Jumper.Application.Base;
using MediatR;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Queries.GetListByEntityDefinitionId;

public class GetListByEntityDefinitionIdEntityPropertyDefinitionQuery : BaseDynamicQuery, IRequest<ListModel<GetListByEntityDefinitionIdEntityPropertyDefinitionResponse>>
{
    public Guid EntityDefinitionId { get; set; }

}
