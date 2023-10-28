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

        public virtual DbSet<ProjectEntity> ProjectEntities { get; set; }

        public virtual DbSet<ProjectEntityProperty> ProjectEntityProperties { get; set; }

        public virtual DbSet<ProjectEntityDependency> ProjectEntityDependencies { get; set; }

        public virtual DbSet<ProjectEntityAction> ProjectEntityActions { get; set; }

        public virtual DbSet<ProjectEntityActionProperty> ProjectEntityActionProperties { get; set; }

        public virtual DbSet<PropertyInputTypeDeclaration> PropertyInputTypeDeclarations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.Write);
        }

        //IEntityTypeConfiguration dan kalıtılan tüm konfigurasyonları işler.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntityActionProperty>().HasOne(w => w.ProjectEntityAction).WithMany(w => w.Properties).HasForeignKey(w => w.ProjectEntityActionId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
