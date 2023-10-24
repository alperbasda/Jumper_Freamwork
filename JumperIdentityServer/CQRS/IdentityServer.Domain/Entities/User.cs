
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using Core.Persistence.Models;
namespace IdentityServer.Domain.Entities;

public class User : Entity<Guid>
{
	public string LastName { get; set; }
	public string UserName { get; set; }
	public string NormalizedMailAddress { get; set; }
	public string MailAddress { get; set; }
	public string NormalizedUserName { get; set; }
	public string FirstName { get; set; }
	public int Status { get; set; }
	public virtual ICollection<UserScope> UserScopes { get; set; }
	public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
	public virtual ICollection<ClientUserRelation> Clients { get; set; }
	public virtual ICollection<UserPassword> UserPasswords { get; set; }
	public virtual ICollection<RoleUserRelation> Roles { get; set; }
}

