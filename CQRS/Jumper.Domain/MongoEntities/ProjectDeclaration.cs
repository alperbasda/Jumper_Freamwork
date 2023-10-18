using Core.Persistence.Models;
using Jumper.Domain.Enums;

namespace Jumper.Domain.MongoEntities
{
    public class ProjectDeclaration : MongoEntity<Guid>, IUserOwnedEntity
    {
        public ProjectDeclaration()
        {
            CacheConfiguration = new CacheConfiguration();
            RabbitMqConfiguration = new RabbitMqConfiguration();
            SeriLogConfigurations = new SeriLogConfigurations();
            NoSqlDatabaseConfiguration = new NoSqlDatabaseConfiguration();
            RelationalDatabaseConfiguration = new RelationalDatabaseConfiguration();
        }
        public Guid UserId { get; set; }

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

        public ProjectStatus ProjectStatus { get; set; }

        public ProjectCreateType ProjectCreateType { get; set; }

    }

    public class RelationalDatabaseConfiguration
    {
        public RelationalDatabaseType RelationalDatabaseType { get; set; }

        public string ConnectionString { get; set; }
    }

    public class NoSqlDatabaseConfiguration
    {
        public NoSqlDatabaseType NoSqlDatabaseType { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public class CacheConfiguration
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string SlidingExpiration { get; set; }

        public string Password { get; set; }

    }

    public class RabbitMqConfiguration
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Port { get; set; }

        public string Host { get; set; }
    }

    public class SeriLogConfigurations
    {
        public SeriLogConfigurations()
        {
            ElasticLogConfiguration = new ElasticLogConfiguration();
            FileLogConfiguration = new FileLogConfiguration();
            MsSqlLogConfiguration = new MsSqlLogConfiguration();
        }
        public ElasticLogConfiguration? ElasticLogConfiguration { get; set; }

        public FileLogConfiguration? FileLogConfiguration { get; set; }

        public MsSqlLogConfiguration? MsSqlLogConfiguration { get; set; }
    }

    public class ElasticLogConfiguration
    {
        public string AppName { get; set; }

        public string Uri { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class FileLogConfiguration
    {
        public string FolderPath { get; set; }
    }

    public class MsSqlLogConfiguration
    {
        public string ConnectionString { get; set; }

        public string TableName { get; set; }

        public bool AutoCreateSqlTable { get; set; }
    }


}
