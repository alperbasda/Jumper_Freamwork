



//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Commands.Create;
using Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;
namespace Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Handlers.Commands.Create;

public class CreateEntityFeatureDefinitionProjectEntityRelationCommandHandler : IRequestHandler<CreateEntityFeatureDefinitionProjectEntityRelationCommand, CreateEntityFeatureDefinitionProjectEntityRelationResponse>
{
    private readonly IEntityFeatureDefinitionProjectEntityRelationDal _entityFeatureDefinitionProjectEntityRelationDal;
    private readonly EntityFeatureDefinitionProjectEntityRelationBusinessRules _entityFeatureDefinitionProjectEntityRelationBusinessRules;
    private readonly IMapper _mapper;

    public CreateEntityFeatureDefinitionProjectEntityRelationCommandHandler(IMapper mapper, IEntityFeatureDefinitionProjectEntityRelationDal entityFeatureDefinitionProjectEntityRelationDal, EntityFeatureDefinitionProjectEntityRelationBusinessRules entityFeatureDefinitionProjectEntityRelationBusinessRules)
    {
        _mapper = mapper;
        _entityFeatureDefinitionProjectEntityRelationDal = entityFeatureDefinitionProjectEntityRelationDal;
        _entityFeatureDefinitionProjectEntityRelationBusinessRules = entityFeatureDefinitionProjectEntityRelationBusinessRules;
    }

    public async Task<CreateEntityFeatureDefinitionProjectEntityRelationResponse> Handle(CreateEntityFeatureDefinitionProjectEntityRelationCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<EntityFeatureDefinitionProjectEntityRelation>(request);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _entityFeatureDefinitionProjectEntityRelationDal.AddAsync(data);

        return _mapper.Map<CreateEntityFeatureDefinitionProjectEntityRelationResponse>(data);
    }
}



