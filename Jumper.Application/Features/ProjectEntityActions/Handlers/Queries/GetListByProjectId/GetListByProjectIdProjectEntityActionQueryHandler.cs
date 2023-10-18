using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectId;
using Jumper.Application.Features.ProjectEntityActions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectEntityActions.Handlers.Queries.GetListByProjectId;

public class GetListByProjectIdProjectEntityActionQueryHandler : IRequestHandler<GetListByProjectIdProjectEntityActionQuery, ListModel<GetListByProjectIdProjectEntityActionResponse>>
{
    private readonly IProjectEntityActionDal _projectEntityActionDal;
    private readonly ProjectEntityActionBusinessRules _projectEntityActionBusinessRules;
    private readonly IMapper _mapper;

    public GetListByProjectIdProjectEntityActionQueryHandler(IMapper mapper, ProjectEntityActionBusinessRules projectEntityCommandBusinessRules,IProjectEntityActionDal projectEntityActionDal)
    {
        _mapper = mapper;
        _projectEntityActionBusinessRules = projectEntityCommandBusinessRules;
        _projectEntityActionDal = projectEntityActionDal;
    }


    public async Task<ListModel<GetListByProjectIdProjectEntityActionResponse>> Handle(GetListByProjectIdProjectEntityActionQuery request, CancellationToken cancellationToken)
    {
        await _projectEntityActionBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(request.ProjectDeclarationRef);

        var datas = await _projectEntityActionDal.GetListByDynamicAsync(request.DynamicQuery, w => w.ProjectEntity.ProjectDeclarationId == request.ProjectDeclarationRef, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, include: w => w.Include(x => x.Properties));

        return _mapper.Map<ListModel<GetListByProjectIdProjectEntityActionResponse>>(datas);
    }
}
