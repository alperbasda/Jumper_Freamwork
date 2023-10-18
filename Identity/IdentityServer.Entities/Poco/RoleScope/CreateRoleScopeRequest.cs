using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.RoleScope
{
    public class CreateRoleScopeRequest : OwnedCreateModel
    {
        public string Scope { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
