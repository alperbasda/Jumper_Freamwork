using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jumper.Persistance.EntityConfigurations
{
    public class PropertyTypeDeclarationConfiguration : IEntityTypeConfiguration<PropertyTypeDeclaration>
    {
        public void Configure(EntityTypeBuilder<PropertyTypeDeclaration> builder)
        {
            builder.ToTable("PropertyTypeDeclarations").HasKey(t => t.Id);

            builder.HasIndex(w => w.DeletedTime);

            builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
            builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
            builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
            builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
            builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

            builder.Property(w => w.Name).HasColumnName("Name").IsRequired();
            builder.Property(w => w.Code).HasColumnName("Code").IsRequired();
            builder.Property(w => w.Description).HasColumnName("Description").IsRequired();



        }
    }
}
