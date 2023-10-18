using AutoMapper;
using EntityBase.Db.Concrete;
using IdentityServer.Entities.Poco.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class ClientScope : OwnedEntity
    {
        [ForeignKey("OwnerId")]
        public virtual Client Client { get; set; }

        public string Scope { get; set; }

        public DateTime? ExpiredDate { get; set; }
    }
    public class ClientScopeProfile : Profile
    {
        public ClientScopeProfile()
        {
            CreateMap<ClientScope, ClientScopeResponse>();

            CreateMap<ClientScope, UpdateClientScopeRequest>().ReverseMap();

            CreateMap<ClientScope, CreateClientScopeRequest>().ReverseMap();
        }
    }
}
