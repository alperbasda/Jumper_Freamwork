
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.AuthMessageses.Commands.BulkCreate;


public class BulkCreateAuthMessagesWrapperCommand : IRequest<List<BulkCreateAuthMessagesResponse>>  
{
    public List<BulkCreateAuthMessagesCommand> Items { get; set; }
}

public class BulkCreateAuthMessagesCommand
{
    
	public int Type { get; set; }
	public string Code { get; set; }
	public int LanguageCode { get; set; }
	public string Message { get; set; }
	public Guid Id { get; set; }
    
}




