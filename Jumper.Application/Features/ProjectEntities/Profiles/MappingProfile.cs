using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectEntities.Commands.Create;
using Jumper.Application.Features.ProjectEntities.Commands.CreateFromDefinition;
using Jumper.Application.Features.ProjectEntities.Commands.Delete;
using Jumper.Application.Features.ProjectEntities.Commands.Update;
using Jumper.Application.Features.ProjectEntities.Commands.UpdateDependencies;
using Jumper.Application.Features.ProjectEntities.Queries.GetById;
using Jumper.Application.Features.ProjectEntities.Queries.GetDependedList;
using Jumper.Application.Features.ProjectEntities.Queries.GetListByProjectId;
using Jumper.Domain.Entities;
using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectEntities.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProjectEntityCommand, ProjectEntity>().ReverseMap();
        CreateMap<ProjectEntity, CreateProjectEntityResponse>().ReverseMap();

        CreateMap<UpdateProjectEntityCommand, ProjectEntity>().ReverseMap();
        CreateMap<ProjectEntity, UpdateProjectEntityResponse>().ReverseMap();

        CreateMap<ProjectEntity, DeleteProjectEntityResponse>().ReverseMap();


        CreateMap<ProjectEntity, CreateFromDefinitionProjectEntityResponse>();

        CreateMap<ProjectEntity, GetByIdProjectEntityResponse>().ReverseMap();

        CreateMap<ProjectEntity, GetListByProjectIdProjectEntityResponse>()
            .ForMember(w => w.ActionCount, c => c.MapFrom(x => x.ProjectEntityActions.Count))
            .ForMember(w => w.PropertyCount, c => c.MapFrom(x => x.Properties.Count));

        CreateMap<Paginate<ProjectEntity>, ListModel<GetListByProjectIdProjectEntityResponse>>().ReverseMap();


    }
}
