using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.UserScopes
{
    public class UpdateIdentityUserScopeRequest : OwnedUpdateModel
    {
        public string Scope { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
