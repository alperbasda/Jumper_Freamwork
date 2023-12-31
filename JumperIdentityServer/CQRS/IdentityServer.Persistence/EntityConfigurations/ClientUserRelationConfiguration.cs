
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using IdentityServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace IdentityServer.Persistence.EntityConfigurations;


public class ClientUserRelationConfiguration : IEntityTypeConfiguration<ClientUserRelation>
{
    public void Configure(EntityTypeBuilder<ClientUserRelation> builder)
    {
        builder.ToTable("ClientUserRelations").HasKey(t => t.Id);
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

    
		builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
		builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
		builder.Property(w => w.ClientId).HasColumnName("ClientId").IsRequired();
		builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
		builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
		builder.Property(w => w.UserId).HasColumnName("UserId").IsRequired();
        
        


    }
}





