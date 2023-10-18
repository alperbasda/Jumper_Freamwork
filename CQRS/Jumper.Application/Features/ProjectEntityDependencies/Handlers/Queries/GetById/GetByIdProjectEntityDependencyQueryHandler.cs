using AutoMapper;
using Jumper.Application.Features.ProjectEntityDependencies.Queries.GetById;
using Jumper.Application.Features.ProjectEntityDependencies.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectEntityDependencies.Handlers.Queries.GetById;

public class GetByIdProjectEntityDependencyQueryHandler : IRequestHandler<GetByIdProjectEntityDependencyQuery, GetByIdProjectEntityDependencyResponse>
{
    IProjectEntityDependencyDal _projectEntityDependencyDal;
    ProjectEntityDependencyBusinessRules _projectEntityDependencyBusinessRules;
    IMapper _mapper;

    public GetByIdProjectEntityDependencyQueryHandler(IProjectEntityDependencyDal projectEntityDependencyDal, ProjectEntityDependencyBusinessRules projectEntityDependencyBusinessRules, IMapper mapper)
    {
        _projectEntityDependencyDal = projectEntityDependencyDal;
        _projectEntityDependencyBusinessRules = projectEntityDependencyBusinessRules;
        _mapper = mapper;
    }


    public async Task<GetByIdProjectEntityDependencyResponse> Handle(GetByIdProjectEntityDependencyQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityDependencyDal.GetAsync(w => w.Id == request.Id, include: w => w.Include(x => x.DependedEntity).Include(x => x.DependsOnEntity)!);

        await _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(data!.DependedId!.Value, data!.DependsOnId!.Value);

        return _mapper.Map<GetByIdProjectEntityDependencyResponse>(data);

    }
}
