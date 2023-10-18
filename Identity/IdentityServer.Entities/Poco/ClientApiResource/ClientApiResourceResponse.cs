using EntityBase.Poco.GetModelBase.Concrete;

namespace IdentityServer.Entities.Poco.ClientApiResource
{
    public class ClientApiResourceResponse : GetModel
    {
        public Guid ApiResourceId { get; set; }

        public Guid ClientId { get; set; }

        public string ClientName { get; set; }

        public string ApiResourceName { get; set; }
    }
}
