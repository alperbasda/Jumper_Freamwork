using AutoMapper;
using Core.ApiHelpers.JwtHelper.Models;
using Core.Persistence.Dynamic;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.EntityPropertyDefinitions.Queries.GetListByEntityDefinitionId;
using Jumper.Application.Features.EntityPropertyDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;


namespace Jumper.Application.Features.EntityPropertyDefinitions.Handlers.Queries.GetListByEntityDefinitionId;

public class GetListByEntityDefinitionIdEntityPropertyDefinitionQueryHandler : IRequestHandler<GetListByEntityDefinitionIdEntityPropertyDefinitionQuery, ListModel<GetListByEntityDefinitionIdEntityPropertyDefinitionResponse>>
{
    IEntityPropertyDefinitionDal _entityPropertyDefinitionDal;
    EntityPropertyDefinitionBusinessRules _entityPropertyDefinitionBusinessRules;
    TokenParameters _tokenParameters;
    IMapper _mapper;

    public GetListByEntityDefinitionIdEntityPropertyDefinitionQueryHandler(IEntityPropertyDefinitionDal entityPropertyDefinitionDal, EntityPropertyDefinitionBusinessRules entityPropertyDefinitionBusinessRules, IMapper mapper, TokenParameters tokenParameters)
    {
        _entityPropertyDefinitionDal = entityPropertyDefinitionDal;
        _entityPropertyDefinitionBusinessRules = entityPropertyDefinitionBusinessRules;
        _mapper = mapper;
        _tokenParameters = tokenParameters;
    }

    public async Task<ListModel<GetListByEntityDefinitionIdEntityPropertyDefinitionResponse>> Handle(GetListByEntityDefinitionIdEntityPropertyDefinitionQuery request, CancellationToken cancellationToken)
    {
        if (!_tokenParameters.IsSuperUser)
        {
            _entityPropertyDefinitionBusinessRules.AddFilterInDynamicQuery(
            request.DynamicQuery,
            new Filter { Field = $"{nameof(EntityPropertyDefinition.EntityDefinition)}.{nameof(EntityPropertyDefinition.EntityDefinition.UserId)}", Logic = Logic.And, Operator = FilterOperator.Equals, Value = _tokenParameters.UserId.ToString() });
        }

        _entityPropertyDefinitionBusinessRules.AddFilterInDynamicQuery(
            request.DynamicQuery,
            new Filter { Field = nameof(EntityPropertyDefinition.EntityDefinitionId), Logic = Logic.And, Operator = FilterOperator.Equals, Value = request.EntityDefinitionId.ToString() });

        var data = await _entityPropertyDefinitionDal.GetListByDynamicAsync(request.DynamicQuery, index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize
           );

        await _entityPropertyDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

        var returnData = _mapper.Map<ListModel<GetListByEntityDefinitionIdEntityPropertyDefinitionResponse>>(data);
        _entityPropertyDefinitionBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);

        return returnData;
    }
}
