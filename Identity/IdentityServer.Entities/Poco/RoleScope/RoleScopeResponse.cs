using EntityBase.Poco.GetModelBase.Concrete;

namespace IdentityServer.Entities.Poco.RoleScope
{
    public class RoleScopeResponse : GetModel
    {
        public Guid OwnerId { get; set; }

        public string Scope { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
