using AutoMapper;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.DeleteById;
using Jumper.Application.Features.ProjectEntityDependencies.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntityDependencies.Handlers.Commands.DeleteById;

public class DeleteByIdProjectEntityDependencyCommandHandler : IRequestHandler<DeleteByIdProjectEntityDependencyCommand, DeleteByIdProjectEntityDependencyResponse>
{
    IProjectEntityDependencyDal _projectEntityDependencyDal;
    ProjectEntityDependencyBusinessRules _projectEntityDependencyBusinessRules;
    IMapper _mapper;

    public DeleteByIdProjectEntityDependencyCommandHandler(IMapper mapper, ProjectEntityDependencyBusinessRules projectEntityDependencyBusinessRules, IProjectEntityDependencyDal projectEntityDependencyDal)
    {
        _mapper = mapper;
        _projectEntityDependencyBusinessRules = projectEntityDependencyBusinessRules;
        _projectEntityDependencyDal = projectEntityDependencyDal;
    }

    public async Task<DeleteByIdProjectEntityDependencyResponse> Handle(DeleteByIdProjectEntityDependencyCommand request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityDependencyDal.GetAsync(w => w.Id == request.Id);


        await _projectEntityDependencyBusinessRules.ThrowExceptionIfDataNull(data);
        var relatedEntities = await _projectEntityDependencyBusinessRules.GetRelatedEntities(data!.DependedId!.Value, data.DependsOnId!.Value);
        _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(relatedEntities);


        await _projectEntityDependencyDal.DeleteAsync(data);

        await _projectEntityDependencyBusinessRules.DeleteRelationTableIfRelationIsNToN(data);
        await _projectEntityDependencyBusinessRules.DeleteRelationProperties(relatedEntities, data.EntityDependencyType, data.DependedId!.Value);


        return _mapper.Map<DeleteByIdProjectEntityDependencyResponse>(data);
    }
}
