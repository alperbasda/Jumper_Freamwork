using Core.Application.Pipelines.Caching;
using MediatR;

namespace Jumper.Application.Features.PropertyTypeDeclarations.Queries.GetAllFromCache;

public class GetAllFromCachePropertyTypeDeclarationQuery : IRequest<List<GetAllFromCachePropertyTypeDeclarationResponse>>, ICachableRequest
{
    public string CacheKey => "PropertyTypeDeclarations";

    public bool BypassCache => false;

    public string? CacheGroupKey => "PropertyTypeDeclarations";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(5);
}
