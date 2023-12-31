
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.Roles.Queries.GetById;
using IdentityServer.Application.Features.Roles.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.Roles.Handlers.Queries.GetById;

public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQuery, GetByIdRoleResponse>
{
    private readonly IRoleDal _roleDal;
    private readonly RoleBusinessRules _roleBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdRoleQueryHandler(IMapper mapper, IRoleDal roleDal, RoleBusinessRules roleBusinessRules)
    {
        _mapper = mapper;
        _roleDal = roleDal;
        _roleBusinessRules = roleBusinessRules;
    }

    public async Task<GetByIdRoleResponse> Handle(GetByIdRoleQuery request, CancellationToken cancellationToken)
    {
        
        var data = await _roleDal.GetAsync(w => w.Id == request.Id, cancellationToken : cancellationToken);
            
        _roleBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        return _mapper.Map<GetByIdRoleResponse>(data);
    }
}



