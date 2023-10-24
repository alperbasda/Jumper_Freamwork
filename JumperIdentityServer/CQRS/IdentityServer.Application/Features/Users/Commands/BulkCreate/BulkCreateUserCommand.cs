
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.Users.Commands.BulkCreate;


public class BulkCreateUserWrapperCommand : IRequest<List<BulkCreateUserResponse>>  
{
    public List<BulkCreateUserCommand> Items { get; set; }
}

public class BulkCreateUserCommand
{
    
	public string LastName { get; set; }
	public string UserName { get; set; }
	public string NormalizedMailAddress { get; set; }
	public string MailAddress { get; set; }
	public string NormalizedUserName { get; set; }
	public string FirstName { get; set; }
	public Guid Id { get; set; }
	public int Status { get; set; }
    
}




