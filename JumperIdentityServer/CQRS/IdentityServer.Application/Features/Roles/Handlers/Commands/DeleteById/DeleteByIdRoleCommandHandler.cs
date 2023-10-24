
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.Roles.Commands.DeleteById;
using IdentityServer.Application.Features.Roles.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.Roles.Handlers.Commands.DeleteById;

public class DeleteByIdRoleCommandHandler : IRequestHandler<DeleteByIdRoleCommand, DeleteByIdRoleResponse>
{
    private readonly IRoleDal _roleDal;
    private readonly RoleBusinessRules _roleBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdRoleCommandHandler(IMapper mapper, IRoleDal roleDal, RoleBusinessRules roleBusinessRules)
    {
        _mapper = mapper;
        _roleDal = roleDal;
        _roleBusinessRules = roleBusinessRules;
    }

    public async Task<DeleteByIdRoleResponse> Handle(DeleteByIdRoleCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _roleDal.GetAsync(w => w.Id == request.Id);
            
        _roleBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _roleDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdRoleResponse>(data);
    }
}


