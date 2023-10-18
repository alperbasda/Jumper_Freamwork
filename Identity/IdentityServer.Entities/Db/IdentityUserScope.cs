using AutoMapper;
using EntityBase.Db.Concrete;
using IdentityServer.Entities.Poco.UserScopes;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class IdentityUserScope : OwnedEntity
    {
        public string Scope { get; set; }

        [ForeignKey("OwnerId")]
        public virtual IdentityUser IdentityUser { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }

    public class IdentityUserScopeProfile: Profile
    {
        public IdentityUserScopeProfile()
        {
            CreateMap<UpdateIdentityUserScopeRequest,IdentityUserScope>().ReverseMap();
            CreateMap<CreateIdentityUserScopeRequest,IdentityUserScope>().ReverseMap();
            CreateMap<IdentityUserScope, IdentityUserScopeResponse>().ReverseMap();
        }
    }
}
