using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.Application.Features.ProjectEntities.Commands.Create;
using Jumper.Application.Features.ProjectEntities.Commands.CreateFromDefinition;
using Jumper.Application.Features.ProjectEntities.Commands.Delete;
using Jumper.Application.Features.ProjectEntities.Commands.Update;
using Jumper.Application.Features.ProjectEntities.Queries.GetById;
using Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.ProjectEntities.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProjectEntityCommand, ProjectEntity>();
        CreateMap<ProjectEntity, CreateProjectEntityResponse>();


        CreateMap<UpdateProjectEntityCommand, ProjectEntity>();
        CreateMap<ProjectEntity, UpdateProjectEntityResponse>();

        CreateMap<ProjectEntity, DeleteProjectEntityResponse>();

        CreateMap<CreateFromDefinitionProjectEntityCommand, ProjectEntity>();



        CreateMap<ProjectEntity, CreateFromDefinitionProjectEntityResponse>();

        CreateMap<ProjectEntity, GetByIdProjectEntityResponse>();

        CreateMap<ProjectEntity, GetListByProjectIdProjectEntityResponse>();

        CreateMap<Paginate<ProjectEntity>, ListModel<GetListByProjectIdProjectEntityResponse>>();


        CreateMap<ProjectEntity, ProjectDeclarationEntityAggregation>()
            .ForMember(w => w.Properties, q => q.MapFrom(c => c.Properties))
            .ForMember(w => w.Actions, q => q.MapFrom(c => c.ProjectEntityActions));
    }
}
