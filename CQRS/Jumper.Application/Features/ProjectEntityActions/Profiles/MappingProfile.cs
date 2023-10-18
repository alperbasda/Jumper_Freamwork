using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
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
        CreateMap<CreateProjectEntityActionCommand, ProjectEntityAction>();
        CreateMap<ProjectEntityAction, CreateProjectEntityActionResponse>();

        CreateMap<ProjectEntityAction, DeleteProjectEntityActionResponse>();

        CreateMap<ProjectEntityAction, GetByIdProjectEntityActionResponse>();

        CreateMap<ProjectEntityAction, GetListByProjectIdProjectEntityActionResponse>();
        CreateMap<Paginate<ProjectEntityAction>, ListModel<GetListByProjectIdProjectEntityActionResponse>>();

        CreateMap<ProjectEntityAction, GetListByProjectEntityIdProjectEntityActionResponse>();
        CreateMap<Paginate<ProjectEntityAction>, ListModel<GetListByProjectEntityIdProjectEntityActionResponse>>();

        CreateMap<ProjectEntityAction, ProjectDeclarationEntityActionAggregation>()
            .ForMember(w => w.Properties, q => q.MapFrom(c => c.Properties));

        //ActionProperty aggregetion olarak yaşamını sürüyor. Kendine ait bir feature u yok. Oyuzden buraya yazdık.
        CreateMap<ProjectEntityActionProperty, ProjectDeclarationEntityActionPropertyAggregation>();

    }
}
