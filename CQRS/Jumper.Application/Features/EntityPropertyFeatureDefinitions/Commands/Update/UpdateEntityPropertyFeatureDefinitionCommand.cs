
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using MediatR;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.EntityPropertyFeatureDefinitions.Commands.Update;

public class UpdateEntityPropertyFeatureDefinitionCommand : IRequest<UpdateEntityPropertyFeatureDefinitionResponse>  
{
    
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Template { get; set; }
	public ProjectEntityPropertyCreationType Type { get; set; }
	public string Namespace { get; set; }
    
}




