using AutoMapper;
using EntityBase.Db.Concrete;
using EntityBase.Enum;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.AuthMessage;

namespace IdentityServer.Entities.Db
{
    public class AuthMessage : Entity
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public MessageType Type { get; set; }

        public LanguageCode LanguageCode { get; set; }
    }

    public class AuthMessageProfile : Profile
    {
        public AuthMessageProfile()
        {
            CreateMap<AuthMessage, AuthMessageResponse>().ReverseMap();

            CreateMap<CreateAuthMessageRequest, AuthMessage>().ReverseMap();

            CreateMap<UpdateAuthMessageRequest, AuthMessage>().ReverseMap();
        }
    }
}
