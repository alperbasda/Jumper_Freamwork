
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

namespace IdentityServer.Application.Features.UserPasswords.Queries.GetById;

public class GetByIdUserPasswordResponse
{
    
	public DateTime CreatedTime { get; set; }
	public DateTime UpdatedTime { get; set; }
	public Guid Id { get; set; }
	public byte[] Password { get; set; }
	public byte[] PasswordSalt { get; set; }
	public DateTime DeletedTime { get; set; }
    
}




