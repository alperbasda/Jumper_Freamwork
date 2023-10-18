using AutoMapper;
using EntityBase.Db.Concrete;
using IdentityServer.Entities.Poco.RoleScope;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class RoleScope : OwnedEntity
    {
        [ForeignKey("OwnerId")]
        public virtual Role Role { get; set; }

        public string Scope { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }

    public class RoleScopeProfile : Profile
    {
        public RoleScopeProfile()
        {
            CreateMap<RoleScope, RoleScopeResponse>().ReverseMap();

            CreateMap<CreateRoleScopeRequest, RoleScope>().ReverseMap();

            CreateMap<UpdateRoleScopeRequest, RoleScope>().ReverseMap();
        }
    }
}
