
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using MediatR;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;

namespace Jumper.Application.Features.EntityPropertyFeatureDefinitions.Queries.GetById;

public class GetByIdEntityPropertyFeatureDefinitionQuery : IRequest<GetByIdEntityPropertyFeatureDefinitionResponse>  
{
    
	public Guid Id { get; set; }
    
}




