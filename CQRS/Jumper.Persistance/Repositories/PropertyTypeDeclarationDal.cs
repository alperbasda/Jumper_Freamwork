using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories
{
    public class PropertyTypeDeclarationDal : EfRepositoryBase<PropertyTypeDeclaration, Guid, JumperDbContext>, IPropertyTypeDeclarationDal
    {
        public PropertyTypeDeclarationDal(JumperDbContext context) : base(context)
        {
        }
    }
}
