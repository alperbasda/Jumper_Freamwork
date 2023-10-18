using AutoMapper;
using EntityBase.Db.Concrete;
using EntityBase.Enum;
using IdentityServer.Entities.Poco.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class Client : Entity
    {
        public string ClientId { get; set; }

        public string Name { get; set; }

        public byte[] ClientSecret { get; set; }

        public byte[] ClientSecretSalt { get; set; }

        public string ClientUrl { get; set; }

        public string LogoUrl { get; set; }

        public string LoginRedirectUrl { get; set; }

        public string LogoutRedirectUrl { get; set; }

        public EntStatus Status { get; set; }

        public virtual ICollection<ClientScope> ClientScopes { get; set; }

        [InverseProperty("Client")]
        public ICollection<ClientApiResource> ClientApiResources { get; set; }
    }

    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientResponse>().ForMember(w=>w.ClientSecretStr,q=>q.Ignore());

            CreateMap<Client, CreateClientRequest>().ForMember(w => w.ClientSecretStr, q => q.Ignore());
            CreateMap<CreateClientRequest, Client>();
            CreateMap<UpdateClientRequest,Client>();
            CreateMap<Client, UpdateClientRequest>().ForMember(w => w.ClientSecretStr, q => q.Ignore());
        }
    }
}
