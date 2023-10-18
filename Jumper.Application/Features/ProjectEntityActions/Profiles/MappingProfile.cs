using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectEntityActions.Commands.Create;
using Jumper.Application.Features.ProjectEntityActions.Commands.Delete;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetById;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectEntityId;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectId;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.ProjectEntityCommandCommands.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProjectEntityActionCommand, ProjectEntityAction>().ReverseMap();
        CreateMap<ProjectEntityAction, CreateProjectEntityActionResponse>().ReverseMap();
        
        CreateMap<ProjectEntityAction, DeleteProjectEntityActionResponse>().ReverseMap();

        CreateMap<ProjectEntityAction, GetByIdProjectEntityActionResponse>().ReverseMap();

        CreateMap<ProjectEntityAction, GetListByProjectIdProjectEntityActionResponse>().ReverseMap();
        CreateMap<Paginate<ProjectEntityAction>, ListModel<GetListByProjectIdProjectEntityActionResponse>>().ReverseMap();

        CreateMap<ProjectEntityAction, GetListByProjectEntityIdProjectEntityActionResponse>().ReverseMap();
        CreateMap<Paginate<ProjectEntityAction>, ListModel<GetListByProjectEntityIdProjectEntityActionResponse>>().ReverseMap();
    }
}
