
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.Roles.Commands.BulkCreate;
using IdentityServer.Application.Features.Roles.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;

using MediatR;
namespace IdentityServer.Application.Features.Roles.Handlers.Commands.BulkCreate;

public class BulkCreateRoleCommandHandler : IRequestHandler<BulkCreateRoleWrapperCommand, List<BulkCreateRoleResponse>>
{
    private readonly IRoleDal _roleDal;
    private readonly RoleBusinessRules _roleBusinessRules;
    private readonly IMapper _mapper;

    public BulkCreateRoleCommandHandler(IMapper mapper, IRoleDal roleDal, RoleBusinessRules roleBusinessRules)
    {
        _mapper = mapper;
        _roleDal = roleDal;
        _roleBusinessRules = roleBusinessRules;
    }

    public async Task<List<BulkCreateRoleResponse>> Handle(BulkCreateRoleWrapperCommand request, CancellationToken cancellationToken)
    {
        var datas = _mapper.Map<List<Role>>(request);

        _roleBusinessRules.SetId(datas);
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _roleDal.AddRangeAsync(datas);

        return _mapper.Map<List<BulkCreateRoleResponse>>(datas);
    }
}



