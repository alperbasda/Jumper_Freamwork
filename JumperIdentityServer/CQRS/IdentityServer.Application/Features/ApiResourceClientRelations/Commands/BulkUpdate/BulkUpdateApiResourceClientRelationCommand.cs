
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.ApiResourceClientRelations.Commands.BulkUpdate;


public class BulkUpdateApiResourceClientRelationWrapperCommand : IRequest<List<BulkUpdateApiResourceClientRelationResponse>>  
{
    public List<BulkUpdateApiResourceClientRelationCommand> Items { get; set; }
}

public class BulkUpdateApiResourceClientRelationCommand
{
    
	public Guid ClientId { get; set; }
	public Guid ApiResourceId { get; set; }
	public Guid Id { get; set; }
    
}




