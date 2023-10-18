using AutoMapper;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.Update;
using Jumper.Application.Features.EntityPropertyDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Handlers.Commands.Update;

public class UpdateEntityPropertyDefinitionCommandHandler : IRequestHandler<UpdateEntityPropertyDefinitionCommand, UpdateEntityPropertyDefinitionResponse>
{
    private readonly IEntityPropertyDefinitionDal _entityPropertyDefinitionDal;
    private readonly EntityPropertyDefinitionBusinessRules _entityPropertyDefinitionBusinessRules;
    private readonly IMapper _mapper;
    
    public UpdateEntityPropertyDefinitionCommandHandler(EntityPropertyDefinitionBusinessRules entityPropertyDefinitionBusinessRules, IEntityPropertyDefinitionDal entityPropertyDefinitionDal, IMapper mapper)
    {
        _entityPropertyDefinitionBusinessRules = entityPropertyDefinitionBusinessRules;
        _entityPropertyDefinitionDal = entityPropertyDefinitionDal;
        _mapper = mapper;
    }

    public async Task<UpdateEntityPropertyDefinitionResponse> Handle(UpdateEntityPropertyDefinitionCommand request, CancellationToken cancellationToken)
    {
        var data = await _entityPropertyDefinitionDal.GetAsync(w => w.Id == request.Id , include: e => e.Include(v => v.EntityDefinition), cancellationToken: cancellationToken);


        await _entityPropertyDefinitionBusinessRules.ThrowExceptionIfDataNull(data);
        
        _entityPropertyDefinitionBusinessRules.ThrowExceptionIfEntityDeclarationOwnerIsNotLoggedUser(data!.EntityDefinition);

        data = _mapper.Map(request, data);

        await _entityPropertyDefinitionBusinessRules.ThrowExceptionIfSameNamedDataExistsForUpdate(data!.Name, data.Id, data.EntityDefinitionId);
        _entityPropertyDefinitionBusinessRules.ThrowExceptionEntityIsConstant(data);

        await _entityPropertyDefinitionDal.UpdateAsync(data!);

        return _mapper.Map<UpdateEntityPropertyDefinitionResponse>(data);
    }
}
