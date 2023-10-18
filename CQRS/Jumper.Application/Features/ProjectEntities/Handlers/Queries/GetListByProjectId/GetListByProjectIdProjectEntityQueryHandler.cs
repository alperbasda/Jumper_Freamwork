using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

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
        var datas = await _projectEntityDal.GetListByDynamicAsync(request.DynamicQuery, w => w.ProjectDeclarationId == request.ProjectDeclarationId, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex);

        if (datas.Count != 0)
        {
            _projectEntityBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(datas.Items.First());
        }

        var returnData = _mapper.Map<ListModel<GetListByProjectIdProjectEntityResponse>>(datas);
        _projectEntityBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}
