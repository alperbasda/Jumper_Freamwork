using EntityBase.Db.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using IdentityServer.Entities.Poco.ApiResource;

namespace IdentityServer.Entities.Db
{
    public class ApiResourceScope : OwnedEntity
    {
        [ForeignKey("OwnerId")]
        public virtual ApiResource ApiResource { get; set; }

        public string Scope { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
    public class ApiResourceScopeProfile: Profile
    {
        public ApiResourceScopeProfile()
        {
            CreateMap<ApiResourceScope, ApiResourceScopeResponse>();

            CreateMap<ApiResourceScope, CreateApiResourceScopeRequest>().ReverseMap();

            CreateMap<ApiResourceScope, UpdateApiResourceScopeRequest>().ReverseMap();

        }
    }
}
