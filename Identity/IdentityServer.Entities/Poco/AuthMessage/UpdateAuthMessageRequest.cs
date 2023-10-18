using EntityBase.Enum;
using EntityBase.Poco.PostModelBase.Concrete;
using IdentityServer.Entities.Enum;

namespace IdentityServer.Entities.Poco.AuthMessage
{
    public class UpdateAuthMessageRequest : UpdateModel
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public MessageType Type { get; set; }

        public LanguageCode LanguageCode { get; set; }
    }
}
