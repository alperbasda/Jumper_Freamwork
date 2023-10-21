using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.EntityDefinitions.Commands.Create;
using Jumper.Application.Features.EntityDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityDefinitions.Commands.Update;
using Jumper.Application.Features.EntityDefinitions.Queries.GetById;
using Jumper.Application.Features.EntityDefinitions.Queries.GetByLoggedUserId;
using Jumper.Application.Features.EntityDefinitions.Queries.GetListDynamic;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.EntityDefinitions.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EntityDefinition, GetListDynamicEntityDefinitionQueryResponse>();
        CreateMap<Paginate<EntityDefinition>, ListModel<GetListDynamicEntityDefinitionQueryResponse>>();

        CreateMap<CreateEntityDefinitionCommand, EntityDefinition>().ReverseMap();
        CreateMap<EntityDefinition, CreateEntityDefinitionResponse>().ReverseMap();

        CreateMap<UpdateEntityDefinitionCommand, EntityDefinition>().ReverseMap();
        CreateMap<EntityDefinition, UpdateEntityDefinitionResponse>().ReverseMap();

        CreateMap<EntityDefinition, DeleteByIdEntityDefinitionResponse>().ReverseMap();

        CreateMap<EntityDefinition, ProjectEntity>()
            .ForMember(w => w.Properties, q => q.MapFrom(c => c.EntityPropertyDefinitions));


        CreateMap<EntityDefinition, GetByIdEntityDefinitionResponse>().ReverseMap();

        CreateMap<EntityDefinition, GetByLoggedUserIdEntityDefinitionResponse>().ReverseMap();
        CreateMap<Paginate<EntityDefinition>, ListModel<GetByLoggedUserIdEntityDefinitionResponse>>().ReverseMap();





    }
}
