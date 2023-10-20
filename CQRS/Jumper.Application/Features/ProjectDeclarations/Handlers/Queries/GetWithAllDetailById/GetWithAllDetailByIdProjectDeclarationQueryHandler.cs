using AutoMapper;
using Jumper.Application.Features.ArchitectureDefinitions.Queries.GetByIdFromCache;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetWithAllDetailById;

public class GetWithAllDetailByIdProjectDeclarationQueryHandler : IRequestHandler<GetWithAllDetailByIdProjectDeclarationQuery, GetWithAllDetailByIdProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    IProjectEntityDal _projectEntityDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    IMapper _mapper;
    IMediator _mediator;

    public GetWithAllDetailByIdProjectDeclarationQueryHandler(IProjectDeclarationDal projectDeclarationDal, IProjectEntityDal projectEntityDal, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IMapper mapper, IMediator mediator)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _projectEntityDal = projectEntityDal;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<GetWithAllDetailByIdProjectDeclarationResponse> Handle(GetWithAllDetailByIdProjectDeclarationQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);
        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(project);

        var returnProjectData = _mapper.Map<GetWithAllDetailByIdProjectDeclarationResponse>(project);

        returnProjectData.Architecture = await _mediator.Send(new GetByIdFromCacheArchitectureDefinitionQuery { Id = request.ArchitectureId });

        var allIncludedData = await _projectEntityDal.GetListAsync(w => w.ProjectDeclarationId == returnProjectData.Id, size: int.MaxValue, cancellationToken: cancellationToken,
            include: w => w.Include(q => q.Depended.Where(w => w.DeletedTime == null))
                           .Include(q => q.DependsOn.Where(w => w.DeletedTime == null))
                           .Include(q => q.Properties.Where(w => w.DeletedTime == null))
                           .Include(q => q.ProjectEntityActions.Where(w => w.DeletedTime == null))
                           .ThenInclude(q => q.Properties));

        returnProjectData.Entities = _mapper.Map<List<ProjectDeclarationEntityAggregation>>(allIncludedData.Items);

        var relations = allIncludedData.Items.Where(w => w.Depended != null).SelectMany(w => w.Depended).ToList();
        relations.AddRange(allIncludedData.Items.Where(w => w.DependsOn != null).SelectMany(w => w.DependsOn).ToList());
        relations = relations.Distinct().ToList();
        returnProjectData.Relations = _mapper.Map<List<ProjectDeclarationRelationAggregation>>(relations);

        _projectDeclarationBusinessRules.FillDependencyEntityNames(returnProjectData);
        _projectDeclarationBusinessRules.AddDefaultActions(returnProjectData);
        _projectDeclarationBusinessRules.FillEntityActionProperties(returnProjectData);

        return returnProjectData;
    }
}
