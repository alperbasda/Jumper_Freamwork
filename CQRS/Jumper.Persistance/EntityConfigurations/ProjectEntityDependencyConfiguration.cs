using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jumper.Persistance.EntityConfigurations;

public class ProjectEntityDependencyConfiguration : IEntityTypeConfiguration<ProjectEntityDependency>

{
    public void Configure(EntityTypeBuilder<ProjectEntityDependency> builder)
    {
        builder.ToTable("ProjectEntityDependencies").HasKey(sc => sc.Id);

        builder.HasIndex(w => w.ProjectDeclarationId);
        builder.HasIndex(w => w.DependsOnId);
        builder.HasIndex(w => w.DependedId);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.ProjectDeclarationId).HasColumnName("ProjectDeclarationId").IsRequired();
        builder.Property(w => w.DependsOnId).HasColumnName("DependsOnId");
        builder.Property(w => w.DependedId).HasColumnName("DependedId");

        builder.HasOne(w => w.DependsOnEntity).WithMany(w => w.DependsOn).HasForeignKey(x => x.DependsOnId);
        builder.HasOne(w => w.DependedEntity).WithMany(w => w.Depended).HasForeignKey(x => x.DependedId);

        builder.Property(w => w.EntityDependencyType).HasColumnName("EntityDependencyType").IsRequired();
    }
}
