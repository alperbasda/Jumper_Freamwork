using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Queries.GetListByProjectId;

public class GetListByProjectIdProjectEntityQueryHandler : IRequestHandler<GetListByProjectIdProjectEntityQuery, ListModel<GetListByProjectIdProjectEntityResponse>>
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly ProjectEntityBusinessRules _projectEntityBusinessRules;
    private readonly IMapper _mapper;

    public GetListByProjectIdProjectEntityQueryHandler(IMapper mapper, ProjectEntityBusinessRules projectEntityBusinessRules, IProjectEntityDal projectEntityDal)
    {
        _mapper = mapper;
        _projectEntityBusinessRules = projectEntityBusinessRules;
        _projectEntityDal = projectEntityDal;
    }

    public async Task<ListModel<GetListByProjectIdProjectEntityResponse>> Handle(GetListByProjectIdProjectEntityQuery request, CancellationToken cancellationToken)
    {
        await _projectEntityBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(request.ProjectDeclarationId);
        
        var datas = await _projectEntityDal.GetListByDynamicAsync(request.DynamicQuery, w => w.Id == request.ProjectDeclarationId, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, include: w => w.Include(q => q.ProjectEntityActions).Include(q => q.Properties));

        return _mapper.Map<ListModel<GetListByProjectIdProjectEntityResponse>>(datas);

    }
}
