
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.RoleUserRelations.Commands.DeleteById;
using IdentityServer.Application.Features.RoleUserRelations.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.RoleUserRelations.Handlers.Commands.DeleteById;

public class DeleteByIdRoleUserRelationCommandHandler : IRequestHandler<DeleteByIdRoleUserRelationCommand, DeleteByIdRoleUserRelationResponse>
{
    private readonly IRoleUserRelationDal _roleUserRelationDal;
    private readonly RoleUserRelationBusinessRules _roleUserRelationBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdRoleUserRelationCommandHandler(IMapper mapper, IRoleUserRelationDal roleUserRelationDal, RoleUserRelationBusinessRules roleUserRelationBusinessRules)
    {
        _mapper = mapper;
        _roleUserRelationDal = roleUserRelationDal;
        _roleUserRelationBusinessRules = roleUserRelationBusinessRules;
    }

    public async Task<DeleteByIdRoleUserRelationResponse> Handle(DeleteByIdRoleUserRelationCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _roleUserRelationDal.GetAsync(w => w.Id == request.Id);
            
        _roleUserRelationBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _roleUserRelationDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdRoleUserRelationResponse>(data);
    }
}



