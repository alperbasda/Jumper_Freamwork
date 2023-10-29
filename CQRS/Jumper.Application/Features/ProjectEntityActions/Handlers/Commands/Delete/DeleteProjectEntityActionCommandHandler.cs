using AutoMapper;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Features.ProjectEntityActions.Commands.Delete;
using Jumper.Application.Features.ProjectEntityActions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Handlers.Commands.Delete;

public class DeleteProjectEntityActionCommandHandler : IRequestHandler<DeleteProjectEntityActionCommand, DeleteProjectEntityActionResponse>
{
    private readonly IProjectEntityActionDal _projectEntityActionDal;
    private readonly ProjectEntityActionBusinessRules _projectEntityActionBusinessRules;
    private readonly IMapper _mapper;
    public DeleteProjectEntityActionCommandHandler(IMapper mapper, ProjectEntityActionBusinessRules ProjectEntityCommandBusinessRules, IProjectEntityActionDal projectEntityActionDal)
    {
        _mapper = mapper;
        _projectEntityActionBusinessRules = ProjectEntityCommandBusinessRules;
        _projectEntityActionDal = projectEntityActionDal;
    }

    public async Task<DeleteProjectEntityActionResponse> Handle(DeleteProjectEntityActionCommand request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityActionDal.GetAsync(w => w.Id == request.Id);
        
        await _projectEntityActionBusinessRules.ThrowExceptionIfDataNull(data);
        await _projectEntityActionBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(data!.ProjectEntityId);

        await _projectEntityActionDal.DeleteAsync(data);

        return _mapper.Map<DeleteProjectEntityActionResponse>(data);
    }
}
