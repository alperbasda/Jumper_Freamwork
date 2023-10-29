
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Commands.Update;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;
namespace Jumper.Application.Features.EntityPropertyFeatureDefinitions.Handlers.Commands.Update;

public class UpdateEntityPropertyFeatureDefinitionCommandHandler : IRequestHandler<UpdateEntityPropertyFeatureDefinitionCommand, UpdateEntityPropertyFeatureDefinitionResponse>
{
    private readonly IEntityPropertyFeatureDefinitionDal _entityPropertyFeatureDefinitionDal;
    private readonly EntityPropertyFeatureDefinitionBusinessRules _entityPropertyFeatureDefinitionBusinessRules;
    private readonly IMapper _mapper;

    public UpdateEntityPropertyFeatureDefinitionCommandHandler(IMapper mapper, IEntityPropertyFeatureDefinitionDal entityPropertyFeatureDefinitionDal, EntityPropertyFeatureDefinitionBusinessRules entityPropertyFeatureDefinitionBusinessRules)
    {
        _mapper = mapper;
        _entityPropertyFeatureDefinitionDal = entityPropertyFeatureDefinitionDal;
        _entityPropertyFeatureDefinitionBusinessRules = entityPropertyFeatureDefinitionBusinessRules;
    }

    public async Task<UpdateEntityPropertyFeatureDefinitionResponse> Handle(UpdateEntityPropertyFeatureDefinitionCommand request, CancellationToken cancellationToken)
    {
        var data = await _entityPropertyFeatureDefinitionDal.GetAsync(w => w.Id == request.Id);

        await _entityPropertyFeatureDefinitionBusinessRules.ThrowExceptionIfDataNull(data);
        
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        _mapper.Map(request, data);
        await _entityPropertyFeatureDefinitionDal.UpdateAsync(data);

        return _mapper.Map<UpdateEntityPropertyFeatureDefinitionResponse>(data);
    }
}



