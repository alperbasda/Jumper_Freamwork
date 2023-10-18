using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectEntityProperties.Commands.Create;
using Jumper.Application.Features.ProjectEntityProperties.Commands.Delete;
using Jumper.Application.Features.ProjectEntityProperties.Queries.GetById;
using Jumper.Application.Features.ProjectEntityProperties.Queries.GetListByProjectEntityId;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.ProjectEntityPropertyProperties.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProjectEntityPropertyCommand, ProjectEntityProperty>().ReverseMap();
        CreateMap<ProjectEntityProperty, CreateProjectEntityPropertyResponse>().ReverseMap();

        CreateMap<ProjectEntityProperty, DeleteProjectEntityPropertyResponse>().ReverseMap();

        CreateMap<ProjectEntityProperty, GetByIdProjectEntityPropertyResponse>().ReverseMap();

        CreateMap<ProjectEntityProperty, GetListByProjectEntityIdProjectEntityPropertyResponse>().ReverseMap();
        CreateMap<Paginate<ProjectEntityProperty>, ListModel<GetListByProjectEntityIdProjectEntityPropertyResponse>>().ReverseMap();
    }
}
