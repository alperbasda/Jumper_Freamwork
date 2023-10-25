using AutoMapper;
using Jumper.Application.Features.PropertyInputTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.PropertyInputTypeDeclarations.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PropertyInputTypeDeclaration, GetAllFromCachePropertyInputTypeDeclarationResponse>();

        }
    }
}
