
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using IdentityServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace IdentityServer.Persistence.EntityConfigurations;


public class ApiResourceScopeConfiguration : IEntityTypeConfiguration<ApiResourceScope>
{
    public void Configure(EntityTypeBuilder<ApiResourceScope> builder)
    {
        builder.ToTable("ApiResourceScopes").HasKey(t => t.Id);
        builder.HasQueryFilter(w => !w.DeletedTime.HasValue);

    
		builder.Property(w => w.DisplayName).HasColumnName("DisplayName").IsRequired();
		builder.Property(w => w.DeletedTime).HasColumnName("DeletedTime");
		builder.Property(w => w.Scope).HasColumnName("Scope").IsRequired();
		builder.Property(w => w.UpdatedTime).HasColumnName("UpdatedTime");
		builder.Property(w => w.Description).HasColumnName("Description").IsRequired();
		builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
		builder.Property(w => w.CreatedTime).HasColumnName("CreatedTime").IsRequired();
		builder.HasOne(w => w.ApiResource);
        
        


    }
}





