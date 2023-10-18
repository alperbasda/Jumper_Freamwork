using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;


namespace Jumper.Application.Features.ProjectDeclarations.Interfaces;

public interface ICreateProjectBase
{
    Guid UserId { get; set; }

    string Name { get; set; }

    string ProjectName { get; }

    string Description { get; set; }

    public NoSqlDatabaseConfiguration NoSqlDatabaseConfiguration { get; set; }

    public RelationalDatabaseConfiguration RelationalDatabaseConfiguration { get; set; }

    bool UseCache { get; set; }

    CacheConfiguration CacheConfiguration { get; set; }

    bool UseRabbitMq { get; set; }

    RabbitMqConfiguration RabbitMqConfiguration { get; set; }

    bool UseSerilog { get; set; }

    SeriLogConfigurations SeriLogConfigurations { get; set; }

    bool CreateApi { get; set; }

    bool CreateUI { get; set; }

    List<ProjectEntity> Entities { get; set; }

    ProjectStatus ProjectStatus { get; set; }

    public ProjectCreateType ProjectCreateType { get; set; }
}
