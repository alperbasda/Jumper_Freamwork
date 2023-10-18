using AutoMapper;
using EntityBase.Db.Concrete;
using EntityBase.Enum;
using IdentityServer.Entities.Poco.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class IdentityUser : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public string PhoneNumber { get; set; }
        
        public string ClientId { get; set; }

      //  public string? DeviceId { get; set; }

        public EntStatus Status { get; set; }

        public virtual ICollection<IdentityUserScope> IdentityUserScopes { get; set; }

        public virtual ICollection<IdentityUserPassword> IdentityUserPasswords { get; set; }

        [InverseProperty("IdentityUser")]
        public virtual ICollection<IdentityUserRole> IdentityUserRoles { get; set; }
    }

    public class IdentityUserProfile : Profile
    {
        public IdentityUserProfile()
        {
            CreateMap<IdentityUser, IdentityUser>();
            CreateMap<IdentityUser, IdentityUserResponse>().ReverseMap();

            CreateMap<CreateIdentityUserRequest, IdentityUser>();

            CreateMap<IdentityUser, CreateIdentityUserRequest>()
                .ForMember(w => w.Password, q => q.Ignore())
                .ForMember(w => w.PasswordConfirm, q => q.Ignore());

            CreateMap<UpdateIdentityUserRequest, IdentityUser>();
        }
    }
}
