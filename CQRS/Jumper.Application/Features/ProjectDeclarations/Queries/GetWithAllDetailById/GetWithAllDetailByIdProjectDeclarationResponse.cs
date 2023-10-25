using Jumper.Domain.Enums;
using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;

public class GetWithAllDetailByIdProjectDeclarationResponse
{
    public ArchitectureDefinition Architecture { get; set; }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string SolutionName => this.Name.Replace(" ", "");

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

    public List<ProjectDeclarationEntityAggregation> Entities { get; set; }

    public List<ProjectDeclarationRelationAggregation> Relations { get; set; }


    public List<string> PropertyTypeNames { get; set; }

}


public class ProjectDeclarationRelationAggregation
{
    public Guid? DependsOnId { get; set; }

    public string? DependsOnName { get; set; }

    public Guid? DependedId { get; set; }

    public string? DependedName { get; set; }

    public EntityDependencyType EntityDependencyType { get; set; }
}


public class ProjectDeclarationEntityAggregation
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool IsConstant { get; set; }

    public DatabaseType DatabaseType { get; set; }

    public List<ProjectDeclarationEntityPropertyAggregation> Properties { get; set; }

    public List<ProjectDeclarationEntityActionAggregation> Actions { get; set; }
}

public class ProjectDeclarationEntityActionAggregation
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool CacheEnabled { get; set; }

    public bool LogEnabled { get; set; }

    public bool IsConstant { get; set; }

    public EntityAction EntityAction { get; set; }

    public List<ProjectDeclarationEntityActionPropertyAggregation> Properties { get; set; }
}

public class ProjectDeclarationEntityActionPropertyAggregation
{
    public Guid Id { get; set; }

    public Guid? ProjectEntityPropertyId { get; set; }

    public string PropertyName { get; set; }

    public string PropertyTypeCode { get; set; }

    public string PropertyInputTypeCode { get; set; }

    public ActionPropertyType ActionPropertyType { get; set; }
}

public class ProjectDeclarationEntityPropertyAggregation
{
    public Guid Id { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public bool IsConstant { get; set; }

    public string Prefix { get; set; } = "";

    public string PropertyInputTypeCode { get; set; }

    public bool IsShowOnRelation { get; set; }

    public int Order { get; set; }
}



