
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.ClientUserRelations.Commands.BulkUpdate;


public class BulkUpdateClientUserRelationWrapperCommand : IRequest<List<BulkUpdateClientUserRelationResponse>>  
{
    public List<BulkUpdateClientUserRelationCommand> Items { get; set; }
}

public class BulkUpdateClientUserRelationCommand
{
    
	public Guid ClientId { get; set; }
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
    
}




