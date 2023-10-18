using AutoMapper;
using EntityBase.Db.Concrete;
using IdentityServer.Entities.Poco.ClientApiResource;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class ClientApiResource : Entity
    {
        public Guid ApiResourceId { get; set; }

        [ForeignKey("ApiResourceId")]
        public ApiResource ApiResource { get; set; }

        public Guid ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }

    public class ClientApiResourceProfile : Profile
    {
        public ClientApiResourceProfile()
        {
            CreateMap<ClientApiResource, ClientApiResourceResponse>()
                .ForMember(w => w.ClientName, q => q.MapFrom(c=>c.Client.Name))
                .ForMember(w => w.ApiResourceName, q => q.MapFrom(c => c.ApiResource.Name));

            CreateMap<ClientApiResource,CreateClientApiResourceRequest>().ReverseMap();
            CreateMap<ClientApiResource,UpdateClientApiResourceRequest>().ReverseMap();
        }
    }
}
