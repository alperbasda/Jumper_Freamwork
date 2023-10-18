using AutoMapper;
using Jumper.Application.Features.EntityDefinitions.Commands.Update;
using Jumper.Application.Features.EntityDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Handlers.Commands.Update;

public class UpdateEntityDefinitionCommandHandler : IRequestHandler<UpdateEntityDefinitionCommand, UpdateEntityDefinitionResponse>
{
    IEntityDefinitionDal _entityDefinitionDal;
    EntityDefinitionBusinessRules _entityDefinitionBusinessRules;
    IMapper _mapper;

    public UpdateEntityDefinitionCommandHandler(IMapper mapper, EntityDefinitionBusinessRules entityDefinitionBusinessRules, IEntityDefinitionDal entityDefinitionDal)
    {
        _mapper = mapper;
        _entityDefinitionBusinessRules = entityDefinitionBusinessRules;
        _entityDefinitionDal = entityDefinitionDal;
    }

    public async Task<UpdateEntityDefinitionResponse> Handle(UpdateEntityDefinitionCommand request, CancellationToken cancellationToken)
    {
        var data = await _entityDefinitionDal.GetAsync(w => w.Id == request.Id);

        await _entityDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

        _entityDefinitionBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(data!);

        data = _mapper.Map(request, data);

        await _entityDefinitionBusinessRules.ThrowExceptionIfSameNamedDataExistsForUpdate(data!);

        await _entityDefinitionDal.UpdateAsync(data!);

        return _mapper.Map<UpdateEntityDefinitionResponse>(data);
    }
}
