using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.UserRole
{
    public class CreateIdentityUserRoleRequest : CreateModel
    {
        public Guid RoleId { get; set; }

        public Guid IdentityUserId { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
