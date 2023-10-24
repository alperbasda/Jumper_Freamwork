
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.ApiResourceScopes.Queries.ListDynamic;
using IdentityServer.Application.Features.ApiResourceScopes.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using Core.Persistence.Models.Responses;
using MediatR;
namespace IdentityServer.Application.Features.ApiResourceScopes.Handlers.Queries.ListDynamic;

public class ListDynamicApiResourceScopeQueryHandler : IRequestHandler<ListDynamicApiResourceScopeQuery, ListModel<ListDynamicApiResourceScopeResponse>>
{
    private readonly IApiResourceScopeDal _apiResourceScopeDal;
    private readonly ApiResourceScopeBusinessRules _apiResourceScopeBusinessRules;
    private readonly IMapper _mapper;

    public ListDynamicApiResourceScopeQueryHandler(IMapper mapper, IApiResourceScopeDal apiResourceScopeDal, ApiResourceScopeBusinessRules apiResourceScopeBusinessRules)
    {
        _mapper = mapper;
        _apiResourceScopeDal = apiResourceScopeDal;
        _apiResourceScopeBusinessRules = apiResourceScopeBusinessRules;
    }

    public async Task<ListModel<ListDynamicApiResourceScopeResponse>> Handle(ListDynamicApiResourceScopeQuery request, CancellationToken cancellationToken)
    {
        var datas = await _apiResourceScopeDal.GetListByDynamicAsync(request.DynamicQuery, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, cancellationToken : cancellationToken);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        var returnData = _mapper.Map<ListModel<ListDynamicApiResourceScopeResponse>>(datas);
        _apiResourceScopeBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}


