
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.BulkCreate;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.Create;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.Update;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.BulkUpdate;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Commands.DeleteById;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Queries.ListDynamic;
using Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Queries.GetById;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.EntityPropertyFeatureDefinitionProjectEntityPropertyRelations.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
		CreateMap<BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand,EntityPropertyFeatureDefinitionProjectEntityPropertyRelation>();
		CreateMap<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation, BulkCreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>();
		CreateMap<CreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand,EntityPropertyFeatureDefinitionProjectEntityPropertyRelation>();
		CreateMap<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation, CreateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>();
		CreateMap<UpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand,EntityPropertyFeatureDefinitionProjectEntityPropertyRelation>();
		CreateMap<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation, UpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>();
		CreateMap<BulkUpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand,EntityPropertyFeatureDefinitionProjectEntityPropertyRelation>();
		CreateMap<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation, BulkUpdateEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>();
		CreateMap<DeleteByIdEntityPropertyFeatureDefinitionProjectEntityPropertyRelationCommand,EntityPropertyFeatureDefinitionProjectEntityPropertyRelation>();
		CreateMap<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation, DeleteByIdEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>();
		CreateMap<Paginate<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation>, ListModel<ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>>();
		CreateMap<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation, ListDynamicEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>();
		CreateMap<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation, GetByIdEntityPropertyFeatureDefinitionProjectEntityPropertyRelationResponse>();
    }
}



