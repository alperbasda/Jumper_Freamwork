




//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using Core.Persistence.Models;
namespace Jumper.Domain.Entities;

public class EntityFeatureDefinitionProjectEntityRelation : Entity<Guid>
{
	public  Guid EntityFeatureDefinitionId { get; set; }
	public virtual EntityFeatureDefinition EntityFeatureDefinition { get; set; }
	public virtual ProjectEntity ProjectEntity { get; set; }
	public  Guid ProjectEntityId { get; set; }
}


