
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.Roles.Commands.Update;

public class UpdateRoleCommand : IRequest<UpdateRoleResponse>  
{
    
	public string Name { get; set; }
	public Guid Id { get; set; }
    
}




