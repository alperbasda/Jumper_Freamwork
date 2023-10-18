using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.Create;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.DeleteById;
using Jumper.Application.Features.EntityPropertyDefinitions.Commands.Update;
using Jumper.Application.Features.EntityPropertyDefinitions.Queries.GetListByEntityDefinitionId;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
        CreateMap<EntityPropertyDefinition, CreateEntityPropertyDefinitionResponse>().ReverseMap();
        CreateMap<EntityPropertyDefinition, CreateEntityPropertyDefinitionCommand>().ReverseMap();

        CreateMap<EntityPropertyDefinition, DeleteByIdEntityPropertyDefinitionResponse>().ReverseMap();

        CreateMap<EntityPropertyDefinition, UpdateEntityPropertyDefinitionResponse>().ReverseMap();
        CreateMap<EntityPropertyDefinition, UpdateEntityPropertyDefinitionCommand>().ReverseMap();

        CreateMap<EntityPropertyDefinition, ProjectEntityProperty>().ReverseMap();

        CreateMap<EntityPropertyDefinition, GetListByEntityDefinitionIdEntityPropertyDefinitionResponse>().ReverseMap();
        CreateMap<Paginate<EntityPropertyDefinition>, ListModel<GetListByEntityDefinitionIdEntityPropertyDefinitionResponse>>().ReverseMap();
    }
}
