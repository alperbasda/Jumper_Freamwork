
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using Jumper.Domain.Enums;

namespace Jumper.Application.Features.EntityFeatureDefinitions.Commands.BulkUpdate;

public class BulkUpdateEntityFeatureDefinitionResponse
{
    
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Template { get; set; }
	public ProjectEntityCreationType Type { get; set; }
	public string Namespace { get; set; }
	public DateTime CreatedTime { get; set; }
	public DateTime? UpdatedTime { get; set; }
	public DateTime? DeletedTime { get; set; }
    
}




