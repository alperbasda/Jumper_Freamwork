using AutoMapper;
using EntityBase.Enum;
using EntityBase.Poco.GetModelBase.Concrete;
using IdentityServer.Entities.Enum;

namespace IdentityServer.Entities.Poco.AuthMessage
{
    public class AuthMessageResponse : GetModel
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public MessageType Type { get; set; }

        public LanguageCode LanguageCode { get; set; }
    }

    
}
