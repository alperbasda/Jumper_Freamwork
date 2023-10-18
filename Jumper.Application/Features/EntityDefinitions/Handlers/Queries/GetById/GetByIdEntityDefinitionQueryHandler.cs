using AutoMapper;
using Jumper.Application.Features.EntityDefinitions.Queries.GetById;
using Jumper.Application.Features.EntityDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Handlers.Queries.GetById;

public class GetByIdEntityDefinitionQueryHandler : IRequestHandler<GetByIdEntityDefinitionQuery, GetByIdEntityDefinitionResponse>
{
    IEntityDefinitionDal _entityDefinitionDal;
    EntityDefinitionBusinessRules _entityDefinitionBusinessRules;
    IMapper _mapper;

    public GetByIdEntityDefinitionQueryHandler(IMapper mapper, EntityDefinitionBusinessRules entityDefinitionBusinessRules, IEntityDefinitionDal entityDefinitionDal)
    {
        _mapper = mapper;
        _entityDefinitionBusinessRules = entityDefinitionBusinessRules;
        _entityDefinitionDal = entityDefinitionDal;
    }

    public async Task<GetByIdEntityDefinitionResponse> Handle(GetByIdEntityDefinitionQuery request, CancellationToken cancellationToken)
    {
        var data = await _entityDefinitionDal.GetAsync(w => w.Id == request.Id);

        await _entityDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

        _entityDefinitionBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(data!);

        return _mapper.Map<GetByIdEntityDefinitionResponse>(data);
    }
}
