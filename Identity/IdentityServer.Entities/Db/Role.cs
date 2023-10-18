using AutoMapper;
using EntityBase.Db.Concrete;
using IdentityServer.Entities.Poco.Role;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<RoleScope> RoleScopes { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<IdentityUserRole> IdentityUserRoles { get; set; }
    }

    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleResponse>().ReverseMap();

            CreateMap<CreateRoleRequest, Role>().ReverseMap();

            CreateMap<UpdateRoleRequest, Role>().ReverseMap();
        }
    }
}
