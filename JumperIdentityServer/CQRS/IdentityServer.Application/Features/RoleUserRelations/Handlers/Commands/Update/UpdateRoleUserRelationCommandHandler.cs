
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.RoleUserRelations.Commands.Update;
using IdentityServer.Application.Features.RoleUserRelations.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.RoleUserRelations.Handlers.Commands.Update;

public class UpdateRoleUserRelationCommandHandler : IRequestHandler<UpdateRoleUserRelationCommand, UpdateRoleUserRelationResponse>
{
    private readonly IRoleUserRelationDal _roleUserRelationDal;
    private readonly RoleUserRelationBusinessRules _roleUserRelationBusinessRules;
    private readonly IMapper _mapper;

    public UpdateRoleUserRelationCommandHandler(IMapper mapper, IRoleUserRelationDal roleUserRelationDal, RoleUserRelationBusinessRules roleUserRelationBusinessRules)
    {
        _mapper = mapper;
        _roleUserRelationDal = roleUserRelationDal;
        _roleUserRelationBusinessRules = roleUserRelationBusinessRules;
    }

    public async Task<UpdateRoleUserRelationResponse> Handle(UpdateRoleUserRelationCommand request, CancellationToken cancellationToken)
    {
        var data = await _roleUserRelationDal.GetAsync(w => w.Id == request.Id);

        _roleUserRelationBusinessRules.ThrowExceptionIfDataNull(data);
        
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        _mapper.Map(request, data);
        await _roleUserRelationDal.UpdateAsync(data);

        return _mapper.Map<UpdateRoleUserRelationResponse>(data);
    }
}



