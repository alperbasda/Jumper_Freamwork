using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.ApiResource
{
    public class UpdateApiResourceScopeRequest : OwnedUpdateModel
    {
        public string Scope { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
