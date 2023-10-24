﻿
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.UserPasswords.Queries.GetByUserId;
using IdentityServer.Application.Features.UserPasswords.Rules;
using IdentityServer.Application.Services.Repositories;
using MediatR;

namespace IdentityServer.Application.Features.UserPasswords.Handlers.Queries.GetById;

public class GetByUserIdUserPasswordQueryHandler : IRequestHandler<GetByUserIdUserPasswordQuery, GetByUserIdUserPasswordResponse>
{
    private readonly IUserPasswordDal _userPasswordDal;
    private readonly UserPasswordBusinessRules _userPasswordBusinessRules;
    private readonly IMapper _mapper;

    public GetByUserIdUserPasswordQueryHandler(IMapper mapper, IUserPasswordDal userPasswordDal, UserPasswordBusinessRules userPasswordBusinessRules)
    {
        _mapper = mapper;
        _userPasswordDal = userPasswordDal;
        _userPasswordBusinessRules = userPasswordBusinessRules;
    }

    public async Task<GetByUserIdUserPasswordResponse> Handle(GetByUserIdUserPasswordQuery request, CancellationToken cancellationToken)
    {
        var data = await _userPasswordDal.GetAsync(w => w.UserId == request.UserId, cancellationToken: cancellationToken);

        _userPasswordBusinessRules.ThrowExceptionIfPasswordWrong(data, request.PasswordStr);
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        return _mapper.Map<GetByUserIdUserPasswordResponse>(data);
    }
}


