using EntityBase.Poco.PostModelBase.Concrete;

namespace IdentityServer.Entities.Poco.Client
{
    public class CreateClientScopeRequest : OwnedCreateModel
    {
        public string Scope { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
}
