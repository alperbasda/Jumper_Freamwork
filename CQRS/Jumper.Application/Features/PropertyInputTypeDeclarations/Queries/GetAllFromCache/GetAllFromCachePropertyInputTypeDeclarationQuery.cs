using Core.Application.Pipelines.Caching;
using MediatR;

namespace Jumper.Application.Features.PropertyInputTypeDeclarations.Queries.GetAllFromCache;

public class GetAllFromCachePropertyInputTypeDeclarationQuery : IRequest<List<GetAllFromCachePropertyInputTypeDeclarationResponse>>,ICachableRequest
{
    public string CacheKey => "PropertyInputTypeDeclarations";

    public bool BypassCache => false;

    public string? CacheGroupKey => "PropertyInputTypeDeclarations";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(5);
}
