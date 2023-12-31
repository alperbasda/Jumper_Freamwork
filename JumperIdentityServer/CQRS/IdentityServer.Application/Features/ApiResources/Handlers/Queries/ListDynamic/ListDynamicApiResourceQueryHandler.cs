
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.ApiResources.Queries.ListDynamic;
using IdentityServer.Application.Features.ApiResources.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using Core.Persistence.Models.Responses;
using MediatR;
namespace IdentityServer.Application.Features.ApiResources.Handlers.Queries.ListDynamic;

public class ListDynamicApiResourceQueryHandler : IRequestHandler<ListDynamicApiResourceQuery, ListModel<ListDynamicApiResourceResponse>>
{
    private readonly IApiResourceDal _apiResourceDal;
    private readonly ApiResourceBusinessRules _apiResourceBusinessRules;
    private readonly IMapper _mapper;

    public ListDynamicApiResourceQueryHandler(IMapper mapper, IApiResourceDal apiResourceDal, ApiResourceBusinessRules apiResourceBusinessRules)
    {
        _mapper = mapper;
        _apiResourceDal = apiResourceDal;
        _apiResourceBusinessRules = apiResourceBusinessRules;
    }

    public async Task<ListModel<ListDynamicApiResourceResponse>> Handle(ListDynamicApiResourceQuery request, CancellationToken cancellationToken)
    {
        var datas = await _apiResourceDal.GetListByDynamicAsync(request.DynamicQuery, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, cancellationToken : cancellationToken);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        var returnData = _mapper.Map<ListModel<ListDynamicApiResourceResponse>>(datas);
        _apiResourceBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}



