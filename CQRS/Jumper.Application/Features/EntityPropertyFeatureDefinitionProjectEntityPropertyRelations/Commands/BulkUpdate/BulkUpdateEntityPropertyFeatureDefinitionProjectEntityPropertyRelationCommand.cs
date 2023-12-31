
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using MediatR;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;

namespace Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.BulkUpdate;


public class BulkUpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationWrapperCommand : IRequest<List<BulkUpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>>  
{
    public List<BulkUpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand> Items { get; set; }
}

public class BulkUpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand
{
    
	public Guid Id { get; set; }
	public Guid EntityPropertyFeatureDefinitionId { get; set; }
	public Guid ProjectEntityPropertyId { get; set; }
    
}




