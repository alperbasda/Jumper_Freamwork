using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.EntityDefinitions.Queries.GetByLoggedUserId;
using Jumper.Application.Features.EntityDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Handlers.Queries.GetByLoggedUserId;

public class GetByLoggedUserIdEntityDefinitionQueryHandler : IRequestHandler<GetByLoggedUserIdEntityDefinitionQuery, ListModel<GetByLoggedUserIdEntityDefinitionResponse>>
{
    IEntityDefinitionDal _entityDefinitionDal;
    EntityDefinitionBusinessRules _entityDefinitionBusinessRules;
    IMapper _mapper;

    public GetByLoggedUserIdEntityDefinitionQueryHandler(IMapper mapper, EntityDefinitionBusinessRules entityDefinitionBusinessRules, IEntityDefinitionDal entityDefinitionDal)
    {
        _mapper = mapper;
        _entityDefinitionBusinessRules = entityDefinitionBusinessRules;
        _entityDefinitionDal = entityDefinitionDal;
    }

    public async Task<ListModel<GetByLoggedUserIdEntityDefinitionResponse>> Handle(GetByLoggedUserIdEntityDefinitionQuery request, CancellationToken cancellationToken)
    {
        var data = await _entityDefinitionDal.GetListAsync(_entityDefinitionBusinessRules.GetUserIdExpressionIfUserNotSuperUser(), size: int.MaxValue);

        await _entityDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

        return _mapper.Map<ListModel<GetByLoggedUserIdEntityDefinitionResponse>>(data);
    }
}
