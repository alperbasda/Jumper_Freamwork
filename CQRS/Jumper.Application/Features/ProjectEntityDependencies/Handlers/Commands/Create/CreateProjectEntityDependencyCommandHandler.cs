using AutoMapper;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;
using Jumper.Application.Features.ProjectEntityDependencies.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityDependencies.Handlers.Commands.Create;

public class CreateProjectEntityDependencyCommandHandler : IRequestHandler<CreateProjectEntityDependencyCommand, CreateProjectEntityDependencyResponse>
{
    IProjectEntityDependencyDal _projectEntityDependencyDal;
    ProjectEntityDependencyBusinessRules _projectEntityDependencyBusinessRules;
    IMapper _mapper;

    public CreateProjectEntityDependencyCommandHandler(IProjectEntityDependencyDal projectEntityDependencyDal, ProjectEntityDependencyBusinessRules projectEntityDependencyBusinessRules, IMapper mapper)
    {
        _projectEntityDependencyDal = projectEntityDependencyDal;
        _projectEntityDependencyBusinessRules = projectEntityDependencyBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateProjectEntityDependencyResponse> Handle(CreateProjectEntityDependencyCommand request, CancellationToken cancellationToken)
    {
        var relatedEntities = await _projectEntityDependencyBusinessRules.GetRelatedEntities(request.DependedId, request.DependsOnId);
        _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(relatedEntities);
        await _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectEntityDependencyAddedBefore(request);

        var data = _mapper.Map<ProjectEntityDependency>(request);

        await _projectEntityDependencyDal.AddAsync(data);

        await _projectEntityDependencyBusinessRules.CreateRelationTableIfRelationIsNToN(relatedEntities, request.EntityDependencyType);
        await _projectEntityDependencyBusinessRules.CreateRelationProperties(relatedEntities, request.EntityDependencyType, request.DependedId);

        return _mapper.Map<CreateProjectEntityDependencyResponse>(data);
    }
}
