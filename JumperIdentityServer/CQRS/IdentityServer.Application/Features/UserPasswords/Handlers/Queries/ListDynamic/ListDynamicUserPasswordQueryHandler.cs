
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.UserPasswords.Queries.ListDynamic;
using IdentityServer.Application.Features.UserPasswords.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using Core.Persistence.Models.Responses;
using MediatR;
namespace IdentityServer.Application.Features.UserPasswords.Handlers.Queries.ListDynamic;

public class ListDynamicUserPasswordQueryHandler : IRequestHandler<ListDynamicUserPasswordQuery, ListModel<ListDynamicUserPasswordResponse>>
{
    private readonly IUserPasswordDal _userPasswordDal;
    private readonly UserPasswordBusinessRules _userPasswordBusinessRules;
    private readonly IMapper _mapper;

    public ListDynamicUserPasswordQueryHandler(IMapper mapper, IUserPasswordDal userPasswordDal, UserPasswordBusinessRules userPasswordBusinessRules)
    {
        _mapper = mapper;
        _userPasswordDal = userPasswordDal;
        _userPasswordBusinessRules = userPasswordBusinessRules;
    }

    public async Task<ListModel<ListDynamicUserPasswordResponse>> Handle(ListDynamicUserPasswordQuery request, CancellationToken cancellationToken)
    {
        var datas = await _userPasswordDal.GetListByDynamicAsync(request.DynamicQuery, size: request.PageRequest.PageSize, index: request.PageRequest.PageIndex, cancellationToken : cancellationToken);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        var returnData = _mapper.Map<ListModel<ListDynamicUserPasswordResponse>>(datas);
        _userPasswordBusinessRules.FillDynamicFilter(returnData, request.DynamicQuery, request.PageRequest);
        return returnData;

    }
}


