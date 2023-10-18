using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectEntityId;
using Jumper.Application.Features.ProjectEntityActions.Rules;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectEntityActions.Handlers.Queries.GetListByProjectEntityId;

public class GetByProjectEntityIdProjectEntityActionQueryHandler : IRequestHandler<GetListByProjectEntityIdProjectEntityActionQuery, ListModel<GetListByProjectEntityIdProjectEntityActionResponse>>
{
    private readonly IProjectEntityActionDal _projectEntityActionDal;
    private readonly ProjectEntityActionBusinessRules _projectEntityActionBusinessRules;
    private readonly IMapper _mapper;

    public GetByProjectEntityIdProjectEntityActionQueryHandler(IMapper mapper, ProjectEntityActionBusinessRules projectEntityCommandBusinessRules, IProjectEntityActionDal projectEntityActionDal)
    {
        _mapper = mapper;
        _projectEntityActionBusinessRules = projectEntityCommandBusinessRules;
        _projectEntityActionDal = projectEntityActionDal;
    }


    public async Task<ListModel<GetListByProjectEntityIdProjectEntityActionResponse>> Handle(GetListByProjectEntityIdProjectEntityActionQuery request, CancellationToken cancellationToken)
    {
        await _projectEntityActionBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(request.ProjectEntityId);

        var datas = await _projectEntityActionDal.GetListByDynamicAsync(request.DynamicQuery, w => w.ProjectEntityId == request.ProjectEntityId, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, include: w => w.Include(c => c.Properties));

        var returnData = _mapper.Map<ListModel<GetListByProjectEntityIdProjectEntityActionResponse>>(datas);

        var properties = await _projectEntityActionBusinessRules.GetProjectEntityProperties(request.ProjectEntityId);

        foreach (var item in returnData.Items)
        {
            var relations = datas.Items.First(w => w.Id == item.Id).Properties.ToList();
            item.RequestProperties = _projectEntityActionBusinessRules.FillEntityActionPropertyNamesStr(properties, relations, ActionPropertyType.Request);
            item.ResponseProperties = _projectEntityActionBusinessRules.FillEntityActionPropertyNamesStr(properties, relations, ActionPropertyType.Response);
        }
        
        _projectEntityActionBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);

        return returnData;
    }
}
