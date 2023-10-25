using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jumper.Persistance.EntityConfigurations;

public class ProjectEntityPropertyConfiguration : IEntityTypeConfiguration<ProjectEntityProperty>
{
    public void Configure(EntityTypeBuilder<ProjectEntityProperty> builder)
    {
        builder.ToTable("ProjectEntityProperties").HasKey(t => t.Id);
        builder.HasIndex(w => w.DeletedTime);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.IsConstant).HasColumnName("IsConstant");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);


        builder.Property(w => w.ProjectEntityId).HasColumnName("ProjectEntityId").IsRequired();
        builder.Property(w => w.PropertyTypeCode).HasColumnName("PropertyTypeCode").IsRequired();
        builder.Property(w => w.PropertyInputTypeCode).HasColumnName("PropertyInputTypeCode").IsRequired();
        builder.Property(w => w.Name).HasColumnName("Name").IsRequired();
        builder.Property(w => w.HasIndex).HasColumnName("HasIndex").IsRequired();
        builder.Property(w => w.IsUnique).HasColumnName("IsUnique").IsRequired();

        builder.HasOne(w => w.ProjectEntity);
    }
}
