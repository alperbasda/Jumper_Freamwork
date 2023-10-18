using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Jumper.Persistance.Contexts
{
    public class JumperDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public JumperDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }


        public virtual DbSet<PropertyTypeDeclaration> PropertyTypeDeclarations { get; set; }

        public virtual DbSet<EntityPropertyDefinition> EntityPropertyDefinitions { get; set; }

        public virtual DbSet<EntityDefinition> EntityDefinitions { get; set; }

        public virtual DbSet<ProjectEntity> ProjectEntities { get; set; }

        public virtual DbSet<ProjectEntityProperty> ProjectEntityProperties { get; set; }

        public virtual DbSet<ProjectEntityDependency> ProjectEntityDependencies { get; set; }

        public virtual DbSet<ProjectEntityAction> ProjectEntityActions { get; set; }

        public virtual DbSet<ProjectEntityActionProperty> ProjectEntityActionProperties { get; set; }

        //IEntityTypeConfiguration dan kalıtılan tüm konfigurasyonları işler.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
