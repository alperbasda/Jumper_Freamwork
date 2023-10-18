using AutoMapper;
using Jumper.Application.Features.EntityDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;


namespace Jumper.Application.Features.EntityDefinitions.Handlers.Commands.DeleteById
{
    public class DeleteByIdEntityDefinitionCommandHandler : IRequestHandler<DeleteByIdEntityDefinitionCommand, DeleteByIdEntityDefinitionResponse>
    {
        IEntityDefinitionDal _entityDefinitionDal;
        EntityDefinitionBusinessRules _entityDefinitionBusinessRules;
        IMapper _mapper;

        public DeleteByIdEntityDefinitionCommandHandler(IMapper mapper, EntityDefinitionBusinessRules entityDefinitionBusinessRules, IEntityDefinitionDal entityDefinitionDal)
        {
            _mapper = mapper;
            _entityDefinitionBusinessRules = entityDefinitionBusinessRules;
            _entityDefinitionDal = entityDefinitionDal;
        }

        public async Task<DeleteByIdEntityDefinitionResponse> Handle(DeleteByIdEntityDefinitionCommand request, CancellationToken cancellationToken)
        {
            var data = await _entityDefinitionDal.GetAsync(w => w.Id == request.Id);
            

            await _entityDefinitionBusinessRules.ThrowExceptionIfDataNull(data);

            _entityDefinitionBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(data!);

            await _entityDefinitionDal.DeleteAsync(data!);

            return _mapper.Map<DeleteByIdEntityDefinitionResponse>(data);
        }
    }
}
