using AutoMapper;
using Core.ApiHelpers.JwtHelper.Models;
using Jumper.Application.Features.ProjectEntities.Queries.GetListByName;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Queries.GetListByName;

public class GetListByNameProjectEntityQueryHandler : IRequestHandler<GetListByNameProjectEntityQuery, List<GetListByNameProjectEntityResponse>>
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly IMapper _mapper;
    private readonly TokenParameters _tokenParameters;
    public GetListByNameProjectEntityQueryHandler(IMapper mapper, IProjectEntityDal projectEntityDal, TokenParameters tokenParameters)
    {
        _mapper = mapper;
        _projectEntityDal = projectEntityDal;
        _tokenParameters = tokenParameters;
    }

    public async Task<List<GetListByNameProjectEntityResponse>> Handle(GetListByNameProjectEntityQuery request, CancellationToken cancellationToken)
    {
        var datas = await _projectEntityDal.GetListAsync(w => w.Name.ToLower().Contains(request.SearchTermLower) && (_tokenParameters.IsSuperUser || w.UserId == _tokenParameters.UserId), size: 10, index: 1);

        var returnData = _mapper.Map<List<GetListByNameProjectEntityResponse>>(datas.Items);
        return returnData;
    }
}
