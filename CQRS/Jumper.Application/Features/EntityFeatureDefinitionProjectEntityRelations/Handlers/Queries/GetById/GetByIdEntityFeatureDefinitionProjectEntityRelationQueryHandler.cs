



//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Queries.GetById;
using Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;
namespace Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Handlers.Queries.GetById;

public class GetByIdEntityFeatureDefinitionProjectEntityRelationQueryHandler : IRequestHandler<GetByIdEntityFeatureDefinitionProjectEntityRelationQuery, GetByIdEntityFeatureDefinitionProjectEntityRelationResponse>
{
    private readonly IEntityFeatureDefinitionProjectEntityRelationDal _entityFeatureDefinitionProjectEntityRelationDal;
    private readonly EntityFeatureDefinitionProjectEntityRelationBusinessRules _entityFeatureDefinitionProjectEntityRelationBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdEntityFeatureDefinitionProjectEntityRelationQueryHandler(IMapper mapper, IEntityFeatureDefinitionProjectEntityRelationDal entityFeatureDefinitionProjectEntityRelationDal, EntityFeatureDefinitionProjectEntityRelationBusinessRules entityFeatureDefinitionProjectEntityRelationBusinessRules)
    {
        _mapper = mapper;
        _entityFeatureDefinitionProjectEntityRelationDal = entityFeatureDefinitionProjectEntityRelationDal;
        _entityFeatureDefinitionProjectEntityRelationBusinessRules = entityFeatureDefinitionProjectEntityRelationBusinessRules;
    }

    public async Task<GetByIdEntityFeatureDefinitionProjectEntityRelationResponse> Handle(GetByIdEntityFeatureDefinitionProjectEntityRelationQuery request, CancellationToken cancellationToken)
    {
        
        var data = await _entityFeatureDefinitionProjectEntityRelationDal.GetAsync(w => w.Id == request.Id, cancellationToken : cancellationToken);
            
        await _entityFeatureDefinitionProjectEntityRelationBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        return _mapper.Map<GetByIdEntityFeatureDefinitionProjectEntityRelationResponse>(data);
    }
}



