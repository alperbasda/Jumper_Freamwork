
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Queries.ListDynamic;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Core.Persistence.Models.Responses;
using MediatR;
namespace Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Handlers.Queries.ListDynamic;

public class ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationQueryHandler : IRequestHandler<ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationQuery, ListModel<ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>>
{
    private readonly IEntityPropertyFeatureDefinitionProjectEntityPropertyRelationDal _entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal;
    private readonly EntityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules _entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules;
    private readonly IMapper _mapper;

    public ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationQueryHandler(IMapper mapper, IEntityPropertyFeatureDefinitionProjectEntityPropertyRelationDal entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal, EntityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules)
    {
        _mapper = mapper;
        _entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal = entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal;
        _entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules = entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules;
    }

    public async Task<ListModel<ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>> Handle(ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationQuery request, CancellationToken cancellationToken)
    {
        
        var datas = await _entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal.GetListByDynamicAsync(request.DynamicQuery, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, cancellationToken : cancellationToken);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        var returnData = _mapper.Map<ListModel<ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>>(datas);
        _entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}


