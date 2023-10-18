using Core.Persistence.Models.Responses;
using Jumper.Application.Base;
using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Queries.GetListDynamic;

public class GetListDynamicEntityDefinitionQuery : BaseDynamicQuery, IRequest<ListModel<GetListDynamicEntityDefinitionQueryResponse>>
{
}
