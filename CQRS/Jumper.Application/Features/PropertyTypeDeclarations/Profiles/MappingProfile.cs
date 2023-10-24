using AutoMapper;
using Jumper.Application.Features.PropertyTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.PropertyTypeDeclarations.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PropertyTypeDeclaration, GetAllFromCachePropertyTypeDeclarationResponse>();

        }
    }
}
