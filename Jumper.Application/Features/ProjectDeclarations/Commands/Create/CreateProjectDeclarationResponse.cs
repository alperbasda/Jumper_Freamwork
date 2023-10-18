using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;


namespace Jumper.Application.Features.ProjectDeclarations.Commands.Create;

public class CreateProjectDeclarationResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool UseDatabase { get; set; }

    public NoSqlDatabaseConfiguration NoSqlDatabaseConfiguration { get; set; }

    public RelationalDatabaseConfiguration RelationalDatabaseConfiguration { get; set; }

    public bool UseCache { get; set; }

    public CacheConfiguration? CacheConfiguration { get; set; }

    public bool UseRabbitMq { get; set; }

    public RabbitMqConfiguration? RabbitMqConfiguration { get; set; }

    public bool UseSerilog { get; set; }

    public SeriLogConfigurations? SeriLogConfigurations { get; set; }

    public bool CreateApi { get; set; }

    public bool CreateUI { get; set; }

}
