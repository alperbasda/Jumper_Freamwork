using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
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
        CreateMap<CreateProjectEntityPropertyCommand, ProjectEntityProperty>();
        CreateMap<ProjectEntityProperty, CreateProjectEntityPropertyResponse>();

        CreateMap<ProjectEntityProperty, DeleteProjectEntityPropertyResponse>();

        CreateMap<ProjectEntityProperty, GetByIdProjectEntityPropertyResponse>();

        CreateMap<ProjectEntityProperty, GetListByProjectEntityIdProjectEntityPropertyResponse>();
        CreateMap<Paginate<ProjectEntityProperty>, ListModel<GetListByProjectEntityIdProjectEntityPropertyResponse>>();

        CreateMap<ProjectEntityProperty, ProjectDeclarationEntityPropertyAggregation>();
        
    }
}
