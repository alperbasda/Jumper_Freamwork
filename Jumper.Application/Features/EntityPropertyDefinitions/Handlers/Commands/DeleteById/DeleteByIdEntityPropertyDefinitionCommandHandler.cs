using AutoMapper;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityPropertyDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Handlers.Commands.DeleteById
{
    public class DeleteByIdEntityPropertyDefinitionCommandHandler : IRequestHandler<DeleteByIdEntityPropertyDefinitionCommand, DeleteByIdEntityPropertyDefinitionResponse>
    {
        private readonly IEntityPropertyDefinitionDal _entityPropertyDefinitionDal;
        private readonly EntityPropertyDefinitionBusinessRules _entityPropertyDefinitionBusinessRules;
        private readonly IMapper _mapper;

        public DeleteByIdEntityPropertyDefinitionCommandHandler(EntityPropertyDefinitionBusinessRules entityPropertyDefinitionBusinessRules, IEntityPropertyDefinitionDal entityPropertyDefinitionDal, IMapper mapper)
        {
            _entityPropertyDefinitionBusinessRules = entityPropertyDefinitionBusinessRules;
            _entityPropertyDefinitionDal = entityPropertyDefinitionDal;
            _mapper = mapper;
        }

        public async Task<DeleteByIdEntityPropertyDefinitionResponse> Handle(DeleteByIdEntityPropertyDefinitionCommand request, CancellationToken cancellationToken)
        {
            var data = await _entityPropertyDefinitionDal.GetAsync(w => w.Id == request.Id, include: e => e.Include(v => v.EntityDefinition), cancellationToken: cancellationToken);

            await _entityPropertyDefinitionBusinessRules.ThrowExceptionIfDataNull(data);
            _entityPropertyDefinitionBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(data!.EntityDefinition);

            await _entityPropertyDefinitionDal.DeleteAsync(data);

            return _mapper.Map<DeleteByIdEntityPropertyDefinitionResponse>(data);
        }
    }
}
