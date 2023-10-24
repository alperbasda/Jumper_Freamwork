



//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.UserScopes.Commands.Create;
using IdentityServer.Application.Features.UserScopes.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.UserScopes.Handlers.Commands.Create;

public class CreateUserScopeCommandHandler : IRequestHandler<CreateUserScopeCommand, CreateUserScopeResponse>
{
    private readonly IUserScopeDal _userScopeDal;
    private readonly UserScopeBusinessRules _userScopeBusinessRules;
    private readonly IMapper _mapper;

    public CreateUserScopeCommandHandler(IMapper mapper, IUserScopeDal userScopeDal, UserScopeBusinessRules userScopeBusinessRules)
    {
        _mapper = mapper;
        _userScopeDal = userScopeDal;
        _userScopeBusinessRules = userScopeBusinessRules;
    }

    public async Task<CreateUserScopeResponse> Handle(CreateUserScopeCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<UserScope>(request);

        _userScopeBusinessRules.SetId(data);
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _userScopeDal.AddAsync(data);

        return _mapper.Map<CreateUserScopeResponse>(data);
    }
}


