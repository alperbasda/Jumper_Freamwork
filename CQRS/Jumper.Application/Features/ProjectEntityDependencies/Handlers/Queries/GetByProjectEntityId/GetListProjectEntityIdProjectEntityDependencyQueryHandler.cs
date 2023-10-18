using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectEntityDependencies.Queries.GetListProjectEntityId;
using Jumper.Application.Features.ProjectEntityDependencies.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectEntityDependencies.Handlers.Queries.GetByProjectEntityId;

public class GetListProjectEntityIdProjectEntityDependencyQueryHandler : IRequestHandler<GetListProjectEntityIdProjectEntityDependencyQuery, ListModel<GetListProjectEntityIdProjectEntityDependencyResponse>>
{
    IProjectEntityDependencyDal _projectEntityDependencyDal;
    ProjectEntityDependencyBusinessRules _projectEntityDependencyBusinessRules;
    IMapper _mapper;

    public GetListProjectEntityIdProjectEntityDependencyQueryHandler(IProjectEntityDependencyDal projectEntityDependencyDal, ProjectEntityDependencyBusinessRules projectEntityDependencyBusinessRules, IMapper mapper)
    {
        _projectEntityDependencyDal = projectEntityDependencyDal;
        _projectEntityDependencyBusinessRules = projectEntityDependencyBusinessRules;
        _mapper = mapper;
    }

    public async Task<ListModel<GetListProjectEntityIdProjectEntityDependencyResponse>> Handle(GetListProjectEntityIdProjectEntityDependencyQuery request, CancellationToken cancellationToken)
    {
        await _projectEntityDependencyBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(request.ProjectDeclarationId);

        var datas = await _projectEntityDependencyDal.GetListByDynamicAsync(request.DynamicQuery, w => w.ProjectDeclarationId == request.ProjectDeclarationId, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, include: w => w.Include(x => x.DependedEntity).Include(x => x.DependsOnEntity)!);

        var returnData = _mapper.Map<ListModel<GetListProjectEntityIdProjectEntityDependencyResponse>>(datas);

        _projectEntityDependencyBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);

        return returnData;
    }
}
