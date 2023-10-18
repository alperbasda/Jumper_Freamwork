using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.DeleteById;
using Jumper.Application.Features.ProjectEntityDependencies.Queries.GetById;
using Jumper.Application.Features.ProjectEntityDependencies.Queries.GetListProjectEntityId;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.ProjectEntityDependencies.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProjectEntityDependencyCommand, ProjectEntityDependency>();
        CreateMap<ProjectEntityDependency, CreateProjectEntityDependencyResponse>();

        CreateMap<ProjectEntityDependency, DeleteByIdProjectEntityDependencyResponse>();

        CreateMap<ProjectEntityDependency, GetByIdProjectEntityDependencyResponse>()
            .ForMember(w => w.DependedEntityName, q => q.MapFrom(c => c.DependedEntity.Name))
            .ForMember(w => w.DependsOnEntityName, q => q.MapFrom(c => c.DependsOnEntity.Name));

        CreateMap<ProjectEntityDependency, GetListProjectEntityIdProjectEntityDependencyResponse>()
            .ForMember(w => w.DependedEntityName, q => q.MapFrom(c => c.DependedEntity.Name))
            .ForMember(w => w.DependsOnEntityName, q => q.MapFrom(c => c.DependsOnEntity.Name));

        CreateMap<Paginate<ProjectEntityDependency>, ListModel<GetListProjectEntityIdProjectEntityDependencyResponse>>();

        CreateMap<ProjectEntityDependency, ProjectDeclarationRelationAggregation>();
        
    }
}
