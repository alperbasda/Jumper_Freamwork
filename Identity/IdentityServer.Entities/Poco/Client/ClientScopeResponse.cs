using EntityBase.Poco.GetModelBase.Concrete;

namespace IdentityServer.Entities.Poco.Client
{
    public class ClientScopeResponse : GetModel
    {
        public string Scope { get; set; }

        public Guid OwnerId { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
