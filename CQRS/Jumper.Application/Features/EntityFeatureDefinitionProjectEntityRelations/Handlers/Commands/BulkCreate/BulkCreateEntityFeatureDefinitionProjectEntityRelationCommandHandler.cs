



//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Commands.BulkCreate;
using Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;

using MediatR;
namespace Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Handlers.Commands.BulkCreate;

public class BulkCreateEntityFeatureDefinitionProjectEntityRelationCommandHandler : IRequestHandler<BulkCreateEntityFeatureDefinitionProjectEntityRelationWrapperCommand, List<BulkCreateEntityFeatureDefinitionProjectEntityRelationResponse>>
{
    private readonly IEntityFeatureDefinitionProjectEntityRelationDal _entityFeatureDefinitionProjectEntityRelationDal;
    private readonly EntityFeatureDefinitionProjectEntityRelationBusinessRules _entityFeatureDefinitionProjectEntityRelationBusinessRules;
    private readonly IMapper _mapper;

    public BulkCreateEntityFeatureDefinitionProjectEntityRelationCommandHandler(IMapper mapper, IEntityFeatureDefinitionProjectEntityRelationDal entityFeatureDefinitionProjectEntityRelationDal, EntityFeatureDefinitionProjectEntityRelationBusinessRules entityFeatureDefinitionProjectEntityRelationBusinessRules)
    {
        _mapper = mapper;
        _entityFeatureDefinitionProjectEntityRelationDal = entityFeatureDefinitionProjectEntityRelationDal;
        _entityFeatureDefinitionProjectEntityRelationBusinessRules = entityFeatureDefinitionProjectEntityRelationBusinessRules;
    }

    public async Task<List<BulkCreateEntityFeatureDefinitionProjectEntityRelationResponse>> Handle(BulkCreateEntityFeatureDefinitionProjectEntityRelationWrapperCommand request, CancellationToken cancellationToken)
    {
        var datas = _mapper.Map<List<EntityFeatureDefinitionProjectEntityRelation>>(request);
        
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _entityFeatureDefinitionProjectEntityRelationDal.AddRangeAsync(datas);

        return _mapper.Map<List<BulkCreateEntityFeatureDefinitionProjectEntityRelationResponse>>(datas);
    }
}



