using EntityBase.Poco.GetModelBase.Concrete;

namespace IdentityServer.Entities.Poco.UserScopes
{
    public class IdentityUserScopeResponse : GetModel
    {
        public string Scope { get; set; }

        public Guid OwnerId { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
