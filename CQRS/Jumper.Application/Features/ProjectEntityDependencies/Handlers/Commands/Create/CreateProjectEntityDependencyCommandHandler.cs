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
        await _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(request.DependedId,request.DependsOnId);
        await _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectEntityDependencyAddedBefore(request);
        _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectEntityDependencyCircular(request);
        

        var data = _mapper.Map<ProjectEntityDependency>(request);

        await _projectEntityDependencyDal.AddAsync(data);

        await _projectEntityDependencyBusinessRules.CreateRelationTableIfRelationIsNToN(request);

        return _mapper.Map<CreateProjectEntityDependencyResponse>(data);
    }
}
