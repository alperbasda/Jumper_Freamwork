
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.RoleUserRelations.Queries.GetById;

public class GetByIdRoleUserRelationQuery : IRequest<GetByIdRoleUserRelationResponse>  
{
    
	public Guid Id { get; set; }
    
}




