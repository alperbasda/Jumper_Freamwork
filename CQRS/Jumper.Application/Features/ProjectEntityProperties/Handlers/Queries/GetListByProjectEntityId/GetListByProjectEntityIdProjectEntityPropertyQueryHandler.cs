using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectEntityProperties.Queries.GetListByProjectEntityId;
using Jumper.Application.Features.ProjectEntityProperties.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Queries.GetById;

public class GetListByProjectEntityIdProjectEntityPropertyQueryHandler : IRequestHandler<GetListByProjectEntityIdProjectEntityPropertyQuery, ListModel<GetListByProjectEntityIdProjectEntityPropertyResponse>>
{
    private readonly IProjectEntityPropertyDal _projectEntityPropertyDal;
    private readonly ProjectEntityPropertyBusinessRules _projectEntityPropertyBusinessRules;
    private readonly IMapper _mapper;

    public GetListByProjectEntityIdProjectEntityPropertyQueryHandler(IMapper mapper, ProjectEntityPropertyBusinessRules projectEntityPropertyBusinessRules, IProjectEntityPropertyDal projectEntityPropertyDal)
    {
        _mapper = mapper;
        _projectEntityPropertyBusinessRules = projectEntityPropertyBusinessRules;
        _projectEntityPropertyDal = projectEntityPropertyDal;
    }


    public async Task<ListModel<GetListByProjectEntityIdProjectEntityPropertyResponse>> Handle(GetListByProjectEntityIdProjectEntityPropertyQuery request, CancellationToken cancellationToken)
    {
        await _projectEntityPropertyBusinessRules.ThrowExceptionIfProjectEntityUserNotLoggedUser(request.ProjectEntityId);

        var datas = await _projectEntityPropertyDal.GetListByDynamicAsync(request.DynamicQuery, w => w.ProjectEntityId == request.ProjectEntityId, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex);

        var returnData = _mapper.Map<ListModel<GetListByProjectEntityIdProjectEntityPropertyResponse>>(datas);

        _projectEntityPropertyBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);

        return returnData;
    }
}
