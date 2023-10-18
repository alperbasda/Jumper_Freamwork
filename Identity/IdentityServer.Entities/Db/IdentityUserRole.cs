using AutoMapper;
using EntityBase.Db.Concrete;
using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Abstract;
using IdentityServer.Entities.Poco.UserRole;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class IdentityUserRole : Entity
    {
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public Guid IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public virtual IdentityUser IdentityUser { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }

    public class IdentityUserRoleProfile : Profile
    {
        public IdentityUserRoleProfile()
        {
            CreateMap<IdentityUserRole, IdentityUserRoleResponse>().ReverseMap();

            CreateMap<CreateIdentityUserRoleRequest, IdentityUserRole>().ReverseMap();

            CreateMap<UpdateIdentityUserRoleRequest, IdentityUserRole>().ReverseMap();
        }
    }
}
