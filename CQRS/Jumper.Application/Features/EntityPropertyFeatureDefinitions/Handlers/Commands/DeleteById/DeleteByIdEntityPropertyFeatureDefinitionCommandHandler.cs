
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityPropertyFeatureDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;
namespace Jumper.Application.Features.EntityPropertyFeatureDefinitions.Handlers.Commands.DeleteById;

public class DeleteByIdEntityPropertyFeatureDefinitionCommandHandler : IRequestHandler<DeleteByIdEntityPropertyFeatureDefinitionCommand, DeleteByIdEntityPropertyFeatureDefinitionResponse>
{
    private readonly IEntityPropertyFeatureDefinitionDal _entityPropertyFeatureDefinitionDal;
    private readonly EntityPropertyFeatureDefinitionBusinessRules _entityPropertyFeatureDefinitionBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdEntityPropertyFeatureDefinitionCommandHandler(IMapper mapper, IEntityPropertyFeatureDefinitionDal entityPropertyFeatureDefinitionDal, EntityPropertyFeatureDefinitionBusinessRules entityPropertyFeatureDefinitionBusinessRules)
    {
        _mapper = mapper;
        _entityPropertyFeatureDefinitionDal = entityPropertyFeatureDefinitionDal;
        _entityPropertyFeatureDefinitionBusinessRules = entityPropertyFeatureDefinitionBusinessRules;
    }

    public async Task<DeleteByIdEntityPropertyFeatureDefinitionResponse> Handle(DeleteByIdEntityPropertyFeatureDefinitionCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _entityPropertyFeatureDefinitionDal.GetAsync(w => w.Id == request.Id);
            
        await _entityPropertyFeatureDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _entityPropertyFeatureDefinitionDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdEntityPropertyFeatureDefinitionResponse>(data);
    }
}



