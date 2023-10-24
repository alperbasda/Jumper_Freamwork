
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using Core.Persistence.Models;
namespace IdentityServer.Domain.Entities;

public class Role : Entity<Guid>
{
	public string Name { get; set; }
	public virtual ICollection<RoleUserRelation> Users { get; set; }
	public virtual ICollection<RoleScope> RoleScopes { get; set; }
}

