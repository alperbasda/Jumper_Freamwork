using AutoMapper;
using EntityBase.Db.Concrete;
using EntityBase.Enum;
using IdentityServer.Entities.Poco.ApiResource;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Entities.Db
{
    public class ApiResource : Entity
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public byte[] ApiSecret { get; set; }

        public byte[] ApiSecretSalt { get; set; }

        public EntStatus Status { get; set; }

        public ICollection<ApiResourceScope> ApiResourceScopes { get; set; }

        [InverseProperty("ApiResource")]
        public ICollection<ClientApiResource> ClientApiResources { get; set; }
    }

    public class ApiResourceProfile : Profile
    {
        public ApiResourceProfile()
        {
            CreateMap<ApiResource, ApiResourceResponse>();

            CreateMap<CreateApiResourceRequest, ApiResource>().ReverseMap();

            CreateMap<UpdateApiResourceRequest, ApiResource>().ReverseMap();
        }
    }
}
