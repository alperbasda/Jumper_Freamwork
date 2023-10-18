using EntityBase.Db.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class IdentityUserPassword : OwnedEntity
    {
        [ForeignKey("OwnerId")]
        public virtual IdentityUser User { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}
