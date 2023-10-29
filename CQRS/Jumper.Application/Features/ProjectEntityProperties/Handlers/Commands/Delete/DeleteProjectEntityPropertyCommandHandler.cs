using AutoMapper;
using Jumper.Application.Features.ProjectEntityProperties.Commands.Delete;
using Jumper.Application.Features.ProjectEntityProperties.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Commands.Create;

public class DeleteProjectEntityPropertyCommandHandler : IRequestHandler<DeleteProjectEntityPropertyCommand, DeleteProjectEntityPropertyResponse>
{
    private readonly IProjectEntityPropertyDal _projectEntityPropertyDal;
    private readonly ProjectEntityPropertyBusinessRules _projectEntityPropertyBusinessRules;
    private readonly IMapper _mapper;
    public DeleteProjectEntityPropertyCommandHandler(IMapper mapper, ProjectEntityPropertyBusinessRules ProjectEntityPropertyBusinessRules, IProjectEntityPropertyDal projectEntityPropertyDal)
    {
        _mapper = mapper;
        _projectEntityPropertyBusinessRules = ProjectEntityPropertyBusinessRules;
        _projectEntityPropertyDal = projectEntityPropertyDal;
    }

    public async Task<DeleteProjectEntityPropertyResponse> Handle(DeleteProjectEntityPropertyCommand request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityPropertyDal.GetAsync(w => w.Id == request.Id);
        
        await _projectEntityPropertyBusinessRules.ThrowExceptionIfDataNull(data);
        await _projectEntityPropertyBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(data!.ProjectEntityId);

        await _projectEntityPropertyDal.DeleteAsync(data);
        return _mapper.Map<DeleteProjectEntityPropertyResponse>(data);
    }
}
