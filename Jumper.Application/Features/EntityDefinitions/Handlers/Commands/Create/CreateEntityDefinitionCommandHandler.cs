using AutoMapper;
using Jumper.Application.Features.EntityDefinitions.Commands.Create;
using Jumper.Application.Features.EntityDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Handlers.Commands.Create
{
    public class CreateEntityDefinitionCommandHandler : IRequestHandler<CreateEntityDefinitionCommand, CreateEntityDefinitionResponse>
    {
        IEntityDefinitionDal _entityDefinitionDal;
        EntityDefinitionBusinessRules _entityDefinitionBusinessRules;
        IMapper _mapper;

        public CreateEntityDefinitionCommandHandler(IMapper mapper, IEntityDefinitionDal entityDefinitionDal, EntityDefinitionBusinessRules entityDefinitionBusinessRules)
        {
            _mapper = mapper;
            _entityDefinitionDal = entityDefinitionDal;
            _entityDefinitionBusinessRules = entityDefinitionBusinessRules;
        }

        public async Task<CreateEntityDefinitionResponse> Handle(CreateEntityDefinitionCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<EntityDefinition>(request);

            await _entityDefinitionBusinessRules.ThrowExceptionIfSameNamedDataExists(data);
            _entityDefinitionBusinessRules.SetUserId(data);

            await _entityDefinitionDal.AddAsync(data);
            await _entityDefinitionBusinessRules.AddDefaultProperties(data.Id);

            return _mapper.Map<CreateEntityDefinitionResponse>(data);
        }
    }
}
