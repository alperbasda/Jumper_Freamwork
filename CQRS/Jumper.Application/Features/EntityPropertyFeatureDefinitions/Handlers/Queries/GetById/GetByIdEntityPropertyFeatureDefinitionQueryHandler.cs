
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Queries.GetById;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;
namespace Jumper.Application.Features.EntityPropertyFeatureDefinitions.Handlers.Queries.GetById;

public class GetByIdEntityPropertyFeatureDefinitionQueryHandler : IRequestHandler<GetByIdEntityPropertyFeatureDefinitionQuery, GetByIdEntityPropertyFeatureDefinitionResponse>
{
    private readonly IEntityPropertyFeatureDefinitionDal _entityPropertyFeatureDefinitionDal;
    private readonly EntityPropertyFeatureDefinitionBusinessRules _entityPropertyFeatureDefinitionBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdEntityPropertyFeatureDefinitionQueryHandler(IMapper mapper, IEntityPropertyFeatureDefinitionDal entityPropertyFeatureDefinitionDal, EntityPropertyFeatureDefinitionBusinessRules entityPropertyFeatureDefinitionBusinessRules)
    {
        _mapper = mapper;
        _entityPropertyFeatureDefinitionDal = entityPropertyFeatureDefinitionDal;
        _entityPropertyFeatureDefinitionBusinessRules = entityPropertyFeatureDefinitionBusinessRules;
    }

    public async Task<GetByIdEntityPropertyFeatureDefinitionResponse> Handle(GetByIdEntityPropertyFeatureDefinitionQuery request, CancellationToken cancellationToken)
    {
        
        var data = await _entityPropertyFeatureDefinitionDal.GetAsync(w => w.Id == request.Id, cancellationToken : cancellationToken);
            
        await _entityPropertyFeatureDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        return _mapper.Map<GetByIdEntityPropertyFeatureDefinitionResponse>(data);
    }
}



