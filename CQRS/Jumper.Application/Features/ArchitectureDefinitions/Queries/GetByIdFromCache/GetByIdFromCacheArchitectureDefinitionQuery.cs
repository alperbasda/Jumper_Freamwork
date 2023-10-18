using Core.Application.Pipelines.Caching;
using Jumper.Domain.MongoEntities;
using MediatR;

namespace Jumper.Application.Features.ArchitectureDefinitions.Queries.GetByIdFromCache;

public class GetByIdFromCacheArchitectureDefinitionQuery : IRequest<ArchitectureDefinition>, ICachableRequest
{
    public Guid Id { get; set; }

    public string CacheKey => $"{Id}_Architecture";

    public bool BypassCache => false;

    public string? CacheGroupKey => $"{Id}_Architecture_Group";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(30);
}
