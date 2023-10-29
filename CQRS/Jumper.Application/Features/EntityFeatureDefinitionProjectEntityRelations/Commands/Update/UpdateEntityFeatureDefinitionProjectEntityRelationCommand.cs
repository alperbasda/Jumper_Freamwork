
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using MediatR;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;

namespace Jumper.Application.Features.EntityFeatureDefinitionProjectEntityRelations.Commands.Update;

public class UpdateEntityFeatureDefinitionProjectEntityRelationCommand : IRequest<UpdateEntityFeatureDefinitionProjectEntityRelationResponse>  
{
    
	public Guid Id { get; set; }
	public Guid EntityFeatureDefinitionId { get; set; }
	public Guid ProjectEntityId { get; set; }
    
}




