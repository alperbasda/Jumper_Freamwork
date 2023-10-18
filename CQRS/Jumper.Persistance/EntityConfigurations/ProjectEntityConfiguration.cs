using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Jumper.Persistance.EntityConfigurations;

public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("ProjectEntities").HasKey(t => t.Id);
        builder.HasIndex(w => w.UserId);
        builder.HasIndex(w => w.ProjectDeclarationId);
        builder.HasIndex(w => w.DeletedTime);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.IsConstant).HasColumnName("IsConstant");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.ProjectDeclarationId).HasColumnName("ProjectDeclarationId").IsRequired();
        builder.Property(w => w.Name).HasColumnName("Name").IsRequired();
        builder.Property(w => w.DatabaseType).HasColumnName("DatabaseType").IsRequired();


        builder.HasMany(w => w.ProjectEntityActions);
        builder.HasMany(w => w.Properties);
        


    }
}
