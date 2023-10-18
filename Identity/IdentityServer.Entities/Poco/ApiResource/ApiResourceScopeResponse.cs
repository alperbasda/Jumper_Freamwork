using EntityBase.Poco.GetModelBase.Concrete;

namespace IdentityServer.Entities.Poco.ApiResource
{
    public class ApiResourceScopeResponse : GetModel
    {
        public Guid OwnerId { get; set; }

        public string Scope { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
