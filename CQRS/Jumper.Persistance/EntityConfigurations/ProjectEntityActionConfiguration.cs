using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Jumper.Persistance.EntityConfigurations;

public class ProjectEntityActionConfiguration : IEntityTypeConfiguration<ProjectEntityAction>
{
    public void Configure(EntityTypeBuilder<ProjectEntityAction> builder)
    {
        builder.ToTable("ProjectEntityActions").HasKey(t => t.Id);

        builder.HasIndex(w => w.DeletedTime);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.Property(w => w.IsConstant).HasColumnName("IsConstant");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);


        builder.Property(w => w.Name).HasColumnName("Name").IsRequired();
        builder.Property(w => w.CacheEnabled).HasColumnName("CacheEnabled").IsRequired();
        builder.Property(w => w.LogEnabled).HasColumnName("LogEnabled").IsRequired();
        builder.Property(w => w.EntityAction).HasColumnName("EntityAction").IsRequired();
        builder.Property(w => w.ProjectEntityId).HasColumnName("ProjectEntityId").IsRequired();

        builder.HasOne(w => w.ProjectEntity);
        

    }
}
