using Core.ApiHelpers.JwtHelper.Models;
using Core.Application.Pipelines.Caching;
using Core.Persistence.Models.Responses;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetByLoggedUserId;

public class GetByLoggedUserIdProjectDeclarationQuery : IRequest<ListModel<GetByLoggedUserIdProjectDeclarationResponse>>, ICachableRequest
{
    TokenParameters _tokenParameters;

    public GetByLoggedUserIdProjectDeclarationQuery(TokenParameters tokenParameters)
    {
        _tokenParameters = tokenParameters;
    }

    public string CacheKey => $"Projects_{_tokenParameters.UserId}";

    public bool BypassCache => false;

    public string? CacheGroupKey => "Projects";

    public TimeSpan? SlidingExpiration => TimeSpan.FromDays(1);
}
