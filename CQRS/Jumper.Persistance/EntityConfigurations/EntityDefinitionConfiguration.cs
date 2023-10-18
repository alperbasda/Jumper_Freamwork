using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Jumper.Persistance.EntityConfigurations;

public class EntityDefinitionConfiguration : IEntityTypeConfiguration<EntityDefinition>
{
    public void Configure(EntityTypeBuilder<EntityDefinition> builder)
    {
        builder.ToTable("EntityDefinitions").HasKey(t => t.Id);

        builder.HasIndex(w => w.DeletedTime);
        builder.HasIndex(w => w.UserId);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
        builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

        builder.Property(w => w.Name).HasColumnName("Name").IsRequired();
        builder.Property(w => w.UserId).HasColumnName("UserId").IsRequired();

        builder.HasMany(w => w.EntityPropertyDefinitions);


    }
}
