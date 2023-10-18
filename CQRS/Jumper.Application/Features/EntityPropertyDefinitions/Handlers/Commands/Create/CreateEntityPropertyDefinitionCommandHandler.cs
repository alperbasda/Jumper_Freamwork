using AutoMapper;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.Create;
using Jumper.Application.Features.EntityPropertyDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Handlers.Commands.Create;

public class CreateEntityPropertyDefinitionCommandHandler : IRequestHandler<CreateEntityPropertyDefinitionCommand, CreateEntityPropertyDefinitionResponse>
{
    private readonly IEntityPropertyDefinitionDal _entityPropertyDefinitionDal;
    private readonly EntityPropertyDefinitionBusinessRules _entityPropertyDefinitionBusinessRules;
    private readonly IMapper _mapper;

    public CreateEntityPropertyDefinitionCommandHandler(EntityPropertyDefinitionBusinessRules entityPropertyDefinitionBusinessRules, IEntityPropertyDefinitionDal entityPropertyDefinitionDal, IMapper mapper)
    {
        _entityPropertyDefinitionBusinessRules = entityPropertyDefinitionBusinessRules;
        _entityPropertyDefinitionDal = entityPropertyDefinitionDal;
        _mapper = mapper;
    }

    public async Task<CreateEntityPropertyDefinitionResponse> Handle(CreateEntityPropertyDefinitionCommand request, CancellationToken cancellationToken)
    {
        await _entityPropertyDefinitionBusinessRules.ThrowExceptionIfSameNamedDataExistsForCreate(request.Name, request.EntityDefinitionId);

        var data = _mapper.Map<EntityPropertyDefinition>(request);

        await _entityPropertyDefinitionBusinessRules.ThrowExceptionIfEntityDeclarationOwnerIsNotLoggedUser(data.EntityDefinitionId);

        await _entityPropertyDefinitionDal.AddAsync(data);

        return _mapper.Map<CreateEntityPropertyDefinitionResponse>(data);
    }
}
