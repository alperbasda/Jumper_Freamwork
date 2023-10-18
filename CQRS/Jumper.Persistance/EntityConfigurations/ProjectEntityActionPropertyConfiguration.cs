using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jumper.Persistance.EntityConfigurations;

public class ProjectEntityActionPropertyConfiguration : IEntityTypeConfiguration<ProjectEntityActionProperty>
{
    public void Configure(EntityTypeBuilder<ProjectEntityActionProperty> builder)
    {
        builder.ToTable("ProjectEntityActionProperties").HasKey(t => t.Id);

        builder.HasIndex(w => w.DeletedTime);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.IsConstant).HasColumnName("IsConstant");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.ProjectEntityActionId).HasColumnName("ProjectEntityActionId").IsRequired();
        builder.Property(w => w.ProjectEntityPropertyId).HasColumnName("ProjectEntityPropertyId").IsRequired();
        builder.Property(w => w.ActionPropertyType).HasColumnName("ActionPropertyType").IsRequired();


        builder.HasOne(w => w.ProjectEntityAction)
            .WithMany(w=>w.Properties)
            .HasForeignKey(w=>w.ProjectEntityActionId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.ProjectEntityProperty)
            .WithMany(w => w.Metods)
            .HasForeignKey(w => w.ProjectEntityPropertyId).OnDelete(DeleteBehavior.Restrict);
    }
}
