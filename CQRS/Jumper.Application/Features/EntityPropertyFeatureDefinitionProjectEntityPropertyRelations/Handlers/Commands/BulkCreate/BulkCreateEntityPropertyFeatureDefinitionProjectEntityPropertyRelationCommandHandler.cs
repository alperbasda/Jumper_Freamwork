
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.BulkCreate;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;

using MediatR;
namespace Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Handlers.Commands.BulkCreate;

public class BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommandHandler : IRequestHandler<BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationWrapperCommand, List<BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>>
{
    private readonly IEntityPropertyFeatureDefinitionProjectEntityPropertyRelationDal _entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal;
    private readonly EntityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules _entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules;
    private readonly IMapper _mapper;

    public BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommandHandler(IMapper mapper, IEntityPropertyFeatureDefinitionProjectEntityPropertyRelationDal entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal, EntityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules)
    {
        _mapper = mapper;
        _entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal = entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal;
        _entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules = entityPropertyFeatureDefinitionProjectEntityPropertyRelationBusinessRules;
    }

    public async Task<List<BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>> Handle(BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationWrapperCommand request, CancellationToken cancellationToken)
    {
        var datas = _mapper.Map<List<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation>>(request);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _entityPropertyFeatureDefinitionProjectEntityPropertyRelationDal.AddRangeAsync(datas);

        return _mapper.Map<List<BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>>(datas);
    }
}



