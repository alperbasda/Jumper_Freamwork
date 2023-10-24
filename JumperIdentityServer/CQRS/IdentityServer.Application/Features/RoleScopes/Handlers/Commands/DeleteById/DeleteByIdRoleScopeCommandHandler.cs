
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.RoleScopes.Commands.DeleteById;
using IdentityServer.Application.Features.RoleScopes.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.RoleScopes.Handlers.Commands.DeleteById;

public class DeleteByIdRoleScopeCommandHandler : IRequestHandler<DeleteByIdRoleScopeCommand, DeleteByIdRoleScopeResponse>
{
    private readonly IRoleScopeDal _roleScopeDal;
    private readonly RoleScopeBusinessRules _roleScopeBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdRoleScopeCommandHandler(IMapper mapper, IRoleScopeDal roleScopeDal, RoleScopeBusinessRules roleScopeBusinessRules)
    {
        _mapper = mapper;
        _roleScopeDal = roleScopeDal;
        _roleScopeBusinessRules = roleScopeBusinessRules;
    }

    public async Task<DeleteByIdRoleScopeResponse> Handle(DeleteByIdRoleScopeCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _roleScopeDal.GetAsync(w => w.Id == request.Id);
            
        _roleScopeBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _roleScopeDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdRoleScopeResponse>(data);
    }
}



