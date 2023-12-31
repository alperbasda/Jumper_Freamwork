
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.ApiResourceScopes.Commands.BulkUpdate;


public class BulkUpdateApiResourceScopeWrapperCommand : IRequest<List<BulkUpdateApiResourceScopeResponse>>  
{
    public List<BulkUpdateApiResourceScopeCommand> Items { get; set; }
}

public class BulkUpdateApiResourceScopeCommand
{
    
	public string DisplayName { get; set; }
	public string Scope { get; set; }
	public string Description { get; set; }
	public Guid Id { get; set; }
    
}




