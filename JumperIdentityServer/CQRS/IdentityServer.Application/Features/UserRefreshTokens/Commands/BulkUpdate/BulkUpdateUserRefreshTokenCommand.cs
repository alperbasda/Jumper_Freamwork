
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.UserRefreshTokens.Commands.BulkUpdate;


public class BulkUpdateUserRefreshTokenWrapperCommand : IRequest<List<BulkUpdateUserRefreshTokenResponse>>  
{
    public List<BulkUpdateUserRefreshTokenCommand> Items { get; set; }
}

public class BulkUpdateUserRefreshTokenCommand
{
    
	public DateTime Expiration { get; set; }
	public Guid Id { get; set; }
	public string Code { get; set; }
    
}




