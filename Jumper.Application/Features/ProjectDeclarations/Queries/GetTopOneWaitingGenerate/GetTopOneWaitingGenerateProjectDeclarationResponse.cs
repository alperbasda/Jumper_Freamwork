using Jumper.Application.Features.ProjectDeclarations.Interfaces;
using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetTopOneWaitingGenerate;

public class GetTopOneWaitingGenerateProjectDeclarationResponse : ICreateProjectBase
{
    public Guid UserId { get; set; }

    public string Name { get; set; }

    private string? projectName;

    public string ProjectName
    {
        get
        {
            if (string.IsNullOrEmpty(projectName))
            {
                projectName = Name.Replace(" ", "_");
            }
            return projectName;
        }
    }

    public string Description { get; set; }

    public NoSqlDatabaseConfiguration NoSqlDatabaseConfiguration { get; set; }

    public RelationalDatabaseConfiguration RelationalDatabaseConfiguration { get; set; }

    public bool UseCache { get; set; }

    public CacheConfiguration CacheConfiguration { get; set; }

    public bool UseRabbitMq { get; set; }

    public RabbitMqConfiguration RabbitMqConfiguration { get; set; }

    public bool UseSerilog { get; set; }

    public SeriLogConfigurations SeriLogConfigurations { get; set; }

    public bool CreateApi { get; set; }

    public bool CreateUI { get; set; }

    public List<ProjectEntity> Entities { get; set; }

    public ProjectStatus ProjectStatus { get; set; }

    public ProjectCreateType ProjectCreateType { get; set; }

    
}
