using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using Jumper.Application.Features.ProjectDeclarations.Commands.Create;
using Jumper.Application.Features.ProjectDeclarations.Commands.DeleteById;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateCacheSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateInfo;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateNoSqlDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRabbitMqSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRelationalDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateSerilogSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetById;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdAllData;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForCacheSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForLogSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForNoSqlDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRabbitMqSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForRelationalDatabaseSettings;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByLoggedUserId;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetListDynamic;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetTopOneWaitingGenerate;

namespace Jumper.Application.Features.ProjectDeclarations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>().ReverseMap();
        CreateMap<Domain.MongoEntities.ProjectDeclaration, CreateProjectDeclarationResponse>().ReverseMap();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetListDynamicProjectDeclarationQueryResponse>().ReverseMap();
        CreateMap<Paginate<Domain.MongoEntities.ProjectDeclaration>, ListModel<GetListDynamicProjectDeclarationQueryResponse>>().ReverseMap();


        
        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByIdForNoSqlDatabaseSettingsProjectDeclarationResponse>();
        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByIdForRelationalDatabaseSettingsProjectDeclarationResponse>();


        
        CreateMap<UpdateInfoProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>().ReverseMap();
        CreateMap<Domain.MongoEntities.ProjectDeclaration, UpdateInfoProjectDeclarationResponse>().ReverseMap();

        CreateMap<DeleteByIdProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>().ReverseMap();
        CreateMap<Domain.MongoEntities.ProjectDeclaration, DeleteByIdProjectDeclarationResponse>().ReverseMap();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByIdProjectDeclarationResponse>()
            .ForMember(w => w.EntityNames, q => q.MapFrom(x => x.Entities.Select(w => w.Name).ToList()));

        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByIdForRabbitMqSettingsProjectDeclarationResponse>().ReverseMap();
        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByIdForLogSettingsProjectDeclarationResponse>().ReverseMap();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByIdForCacheSettingsProjectDeclarationResponse>().ReverseMap();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByLoggedUserIdProjectDeclarationResponse>().ReverseMap();

        CreateMap<Paginate<Domain.MongoEntities.ProjectDeclaration>, ListModel<GetByLoggedUserIdProjectDeclarationResponse>>().ReverseMap();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetByIdAllDataProjectDeclarationResponse>().ReverseMap();
        CreateMap<Domain.MongoEntities.ProjectDeclaration, GetTopOneWaitingGenerateProjectDeclarationResponse>().ReverseMap();


        CreateMap<Domain.MongoEntities.ProjectDeclaration, UpdateSerilogSettingsProjectDeclarationResponse>();
        CreateMap<UpdateSerilogSettingsProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, UpdateRabbitMqSettingsProjectDeclarationResponse>();
        CreateMap<UpdateRabbitMqSettingsProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, UpdateCacheSettingsProjectDeclarationResponse>();
        CreateMap<UpdateCacheSettingsProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, UpdateRelationalDatabaseSettingsProjectDeclarationResponse>();
        CreateMap<UpdateRelationalDatabaseSettingsProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>();

        CreateMap<Domain.MongoEntities.ProjectDeclaration, UpdateNoSqlDatabaseSettingsProjectDeclarationResponse>();
        CreateMap<UpdateNoSqlDatabaseSettingsProjectDeclarationCommand, Domain.MongoEntities.ProjectDeclaration>();
        



    }
}
