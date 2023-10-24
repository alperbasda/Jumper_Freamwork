
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.Users.Queries.ListDynamic;
using IdentityServer.Application.Features.Users.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using Core.Persistence.Models.Responses;
using MediatR;
namespace IdentityServer.Application.Features.Users.Handlers.Queries.ListDynamic;

public class ListDynamicUserQueryHandler : IRequestHandler<ListDynamicUserQuery, ListModel<ListDynamicUserResponse>>
{
    private readonly IUserDal _userDal;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public ListDynamicUserQueryHandler(IMapper mapper, IUserDal userDal, UserBusinessRules userBusinessRules)
    {
        _mapper = mapper;
        _userDal = userDal;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<ListModel<ListDynamicUserResponse>> Handle(ListDynamicUserQuery request, CancellationToken cancellationToken)
    {
        var datas = await _userDal.GetListByDynamicAsync(request.DynamicQuery, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, cancellationToken : cancellationToken);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        var returnData = _mapper.Map<ListModel<ListDynamicUserResponse>>(datas);
        _userBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}


