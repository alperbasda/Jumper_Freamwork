using AutoMapper;
using Jumper.Application.Features.ProjectEntityActions.Commands.Create;
using Jumper.Application.Features.ProjectEntityActions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityActions.Handlers.Commands.Create;

public class CreateProjectEntityActionCommandHandler : IRequestHandler<CreateProjectEntityActionCommand, CreateProjectEntityActionResponse>
{
    private readonly IProjectEntityActionDal _projectEntityActionDal;
    private readonly ProjectEntityActionBusinessRules _projectEntityActionBusinessRules;
    private readonly IMapper _mapper;

    public CreateProjectEntityActionCommandHandler(IMapper mapper, ProjectEntityActionBusinessRules ProjectEntityCommandBusinessRules, IProjectEntityActionDal projectEntityActionDal)
    {
        _mapper = mapper;
        _projectEntityActionBusinessRules = ProjectEntityCommandBusinessRules;
        _projectEntityActionDal = projectEntityActionDal;
    }

    public async Task<CreateProjectEntityActionResponse> Handle(CreateProjectEntityActionCommand request, CancellationToken cancellationToken)
    {
        await _projectEntityActionBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(request.ProjectEntityId);
        await _projectEntityActionBusinessRules.ThrowExceptionIfSamaNameProjectEntityActionExists(request.Name);

        var projectEntityAction = _mapper.Map<ProjectEntityAction>(request);

        _projectEntityActionBusinessRules.MapProjectEntityActionProperties(request, projectEntityAction);

        await _projectEntityActionDal.AddAsync(projectEntityAction);
        return _mapper.Map<CreateProjectEntityActionResponse>(projectEntityAction);
    }
}
