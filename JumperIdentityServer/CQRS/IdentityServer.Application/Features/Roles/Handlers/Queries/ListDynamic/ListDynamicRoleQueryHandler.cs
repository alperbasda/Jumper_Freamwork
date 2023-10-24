
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.Roles.Queries.ListDynamic;
using IdentityServer.Application.Features.Roles.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using Core.Persistence.Models.Responses;
using MediatR;
namespace IdentityServer.Application.Features.Roles.Handlers.Queries.ListDynamic;

public class ListDynamicRoleQueryHandler : IRequestHandler<ListDynamicRoleQuery, ListModel<ListDynamicRoleResponse>>
{
    private readonly IRoleDal _roleDal;
    private readonly RoleBusinessRules _roleBusinessRules;
    private readonly IMapper _mapper;

    public ListDynamicRoleQueryHandler(IMapper mapper, IRoleDal roleDal, RoleBusinessRules roleBusinessRules)
    {
        _mapper = mapper;
        _roleDal = roleDal;
        _roleBusinessRules = roleBusinessRules;
    }

    public async Task<ListModel<ListDynamicRoleResponse>> Handle(ListDynamicRoleQuery request, CancellationToken cancellationToken)
    {
        var datas = await _roleDal.GetListByDynamicAsync(request.DynamicQuery, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, cancellationToken : cancellationToken);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        var returnData = _mapper.Map<ListModel<ListDynamicRoleResponse>>(datas);
        _roleBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}



