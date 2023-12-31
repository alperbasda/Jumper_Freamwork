



//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.UserScopes.Queries.ListDynamic;
using IdentityServer.Application.Features.UserScopes.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using Core.Persistence.Models.Responses;
using MediatR;
namespace IdentityServer.Application.Features.UserScopes.Handlers.Queries.ListDynamic;

public class ListDynamicUserScopeQueryHandler : IRequestHandler<ListDynamicUserScopeQuery, ListModel<ListDynamicUserScopeResponse>>
{
    private readonly IUserScopeDal _userScopeDal;
    private readonly UserScopeBusinessRules _userScopeBusinessRules;
    private readonly IMapper _mapper;

    public ListDynamicUserScopeQueryHandler(IMapper mapper, IUserScopeDal userScopeDal, UserScopeBusinessRules userScopeBusinessRules)
    {
        _mapper = mapper;
        _userScopeDal = userScopeDal;
        _userScopeBusinessRules = userScopeBusinessRules;
    }

    public async Task<ListModel<ListDynamicUserScopeResponse>> Handle(ListDynamicUserScopeQuery request, CancellationToken cancellationToken)
    {
        var datas = await _userScopeDal.GetListByDynamicAsync(request.DynamicQuery, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, cancellationToken : cancellationToken);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        var returnData = _mapper.Map<ListModel<ListDynamicUserScopeResponse>>(datas);
        _userScopeBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}



