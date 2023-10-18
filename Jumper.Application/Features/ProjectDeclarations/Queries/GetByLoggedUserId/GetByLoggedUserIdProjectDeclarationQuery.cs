using Core.Persistence.Models.Responses;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByLoggedUserId;

public class GetByLoggedUserIdProjectDeclarationQuery : IRequest<ListModel<GetByLoggedUserIdProjectDeclarationResponse>>
{
}
