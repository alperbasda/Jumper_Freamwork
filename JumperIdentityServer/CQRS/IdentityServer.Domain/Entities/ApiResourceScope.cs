
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using Core.Persistence.Models;
namespace IdentityServer.Domain.Entities;

public class ApiResourceScope : Entity<Guid>
{
	public string DisplayName { get; set; }
	public string Scope { get; set; }
	public string Description { get; set; }
	public Guid ApiResourceId { get; set; }
	public virtual ApiResource ApiResource { get; set; }
}


