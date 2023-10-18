using AutoMapper;
using EntityBase.Db.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class IdentityUserRefreshToken : UserOwnedEntity
    {
        [ForeignKey("OwnerId")]
        public virtual IdentityUser User { get; set; }

        public string Code { get; set; }

        public string ClientId { get; set; }

        public DateTime Expiration { get; set; }
    }

    public class IdentityUserRefreshTokenProfile : Profile
    {
        public IdentityUserRefreshTokenProfile()
        {
            
        }
    }
}
