using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.RoleScope
{
    public class UpdateRoleScopeRequest : OwnedUpdateModel
    {
        public string Scope { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
