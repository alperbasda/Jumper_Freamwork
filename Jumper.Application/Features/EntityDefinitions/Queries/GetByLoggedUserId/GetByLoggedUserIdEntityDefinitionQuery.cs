using Core.Persistence.Models.Responses;
using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Queries.GetByLoggedUserId;

public class GetByLoggedUserIdEntityDefinitionQuery : IRequest<ListModel<GetByLoggedUserIdEntityDefinitionResponse>>
{
}
