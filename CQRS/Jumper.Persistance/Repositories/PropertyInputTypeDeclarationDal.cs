using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class PropertyInputTypeDeclarationDal : EfRepositoryBase<PropertyInputTypeDeclaration, Guid, JumperDbContext>, IPropertyInputTypeDeclarationDal
{
    public PropertyInputTypeDeclarationDal(JumperDbContext context) : base(context)
    {
    }
}
