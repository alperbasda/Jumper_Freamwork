using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Jumper.Persistance.EntityConfigurations
{
    public class EntityPropertyDefinitionConfiguration : IEntityTypeConfiguration<EntityPropertyDefinition>
    {
        public void Configure(EntityTypeBuilder<EntityPropertyDefinition> builder)
        {
            builder.ToTable("EntityPropertyDefinitions").HasKey(t => t.Id);

            builder.HasIndex(w => w.DeletedTime);

            builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
            builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
            builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
            builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
            builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

            builder.Property(w => w.PropertyTypeCode).HasColumnName("PropertyTypeCode").IsRequired();
            builder.Property(w => w.Name).HasColumnName("Name").IsRequired();
            builder.Property(w => w.EntityDefinitionId).HasColumnName("EntityDefinitionId").IsRequired();
            builder.Property(w => w.PropertyPocoType).HasColumnName("PropertyPocoType").IsRequired();

            builder.HasOne(w => w.EntityDefinition);


        }
    }
}
