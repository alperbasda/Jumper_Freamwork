
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Commands.BulkCreate;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;

using MediatR;
namespace Jumper.Application.Features.EntityPropertyFeatureDefinitions.Handlers.Commands.BulkCreate;

public class BulkCreateEntityPropertyFeatureDefinitionCommandHandler : IRequestHandler<BulkCreateEntityPropertyFeatureDefinitionWrapperCommand, List<BulkCreateEntityPropertyFeatureDefinitionResponse>>
{
    private readonly IEntityPropertyFeatureDefinitionDal _entityPropertyFeatureDefinitionDal;
    private readonly EntityPropertyFeatureDefinitionBusinessRules _entityPropertyFeatureDefinitionBusinessRules;
    private readonly IMapper _mapper;

    public BulkCreateEntityPropertyFeatureDefinitionCommandHandler(IMapper mapper, IEntityPropertyFeatureDefinitionDal entityPropertyFeatureDefinitionDal, EntityPropertyFeatureDefinitionBusinessRules entityPropertyFeatureDefinitionBusinessRules)
    {
        _mapper = mapper;
        _entityPropertyFeatureDefinitionDal = entityPropertyFeatureDefinitionDal;
        _entityPropertyFeatureDefinitionBusinessRules = entityPropertyFeatureDefinitionBusinessRules;
    }

    public async Task<List<BulkCreateEntityPropertyFeatureDefinitionResponse>> Handle(BulkCreateEntityPropertyFeatureDefinitionWrapperCommand request, CancellationToken cancellationToken)
    {
        var datas = _mapper.Map<List<EntityPropertyFeatureDefinition>>(request);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _entityPropertyFeatureDefinitionDal.AddRangeAsync(datas);

        return _mapper.Map<List<BulkCreateEntityPropertyFeatureDefinitionResponse>>(datas);
    }
}


