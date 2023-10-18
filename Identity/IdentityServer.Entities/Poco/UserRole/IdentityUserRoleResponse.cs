
using EntityBase.Poco.GetModelBase.Concrete;

namespace IdentityServer.Entities.Poco.UserRole
{
    public class IdentityUserRoleResponse : GetModel
    {
        public Guid RoleId { get; set; }

        public Guid IdentityUserId { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
