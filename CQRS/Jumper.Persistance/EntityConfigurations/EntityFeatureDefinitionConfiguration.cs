
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 29.10.2023 12:13
//---------------------------------------------------------------------------------------

using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Jumper.Persistence.EntityConfigurations;


public class EntityFeatureDefinitionConfiguration : IEntityTypeConfiguration<EntityFeatureDefinition>
{
    public void Configure(EntityTypeBuilder<EntityFeatureDefinition> builder)
    {
        builder.ToTable("EntityFeatureDefinitions").HasKey(t => t.Id);
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

    
		builder.Property(w => w.Id).HasColumnName("Id").IsRequired(true);
		builder.Property(w => w.Name).HasColumnName("Name").IsRequired(true);
		builder.Property(w => w.Description).HasColumnName("Description").IsRequired(true);
		builder.Property(w => w.Template).HasColumnName("Template").IsRequired(true);
		builder.Property(w => w.Type).HasColumnName("Type").IsRequired(true);
		builder.Property(w => w.Namespace).HasColumnName("Namespace").IsRequired(true);
		builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired(true);
		builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime").IsRequired(false);
		builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime").IsRequired(false);
        
        


    }
}




