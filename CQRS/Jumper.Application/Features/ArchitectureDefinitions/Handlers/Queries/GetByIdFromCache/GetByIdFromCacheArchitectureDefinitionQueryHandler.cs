using Jumper.Application.Features.ArchitectureDefinitions.Queries.GetByIdFromCache;
using Jumper.Application.Features.ArchitectureDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.MongoEntities;
using MediatR;

namespace Jumper.Application.Features.ArchitectureDefinitions.Handlers.Queries.GetByIdFromCache;

public class GetByIdFromCacheArchitectureDefinitionQueryHandler : IRequestHandler<GetByIdFromCacheArchitectureDefinitionQuery, ArchitectureDefinition>
{
    private readonly IArchitectureDefinitionDal _architectureDefinitionDal;
    private readonly ArchitectureDefinitionBusinessRules _architectureDefinitionBusinessRules;
    public GetByIdFromCacheArchitectureDefinitionQueryHandler(IArchitectureDefinitionDal architectureDefinitionDal, ArchitectureDefinitionBusinessRules architectureDefinitionBusinessRules)
    {
        _architectureDefinitionDal = architectureDefinitionDal;
        _architectureDefinitionBusinessRules = architectureDefinitionBusinessRules;
    }

    public async Task<ArchitectureDefinition> Handle(GetByIdFromCacheArchitectureDefinitionQuery request, CancellationToken cancellationToken)
    {
        var data = await _architectureDefinitionDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);
        await _architectureDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

        return data!;
    }
}
