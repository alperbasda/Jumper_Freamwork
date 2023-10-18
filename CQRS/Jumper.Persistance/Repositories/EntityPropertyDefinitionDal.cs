using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class EntityPropertyDefinitionDal : EfRepositoryBase<EntityPropertyDefinition, Guid, JumperDbContext>, IEntityPropertyDefinitionDal
{
    public EntityPropertyDefinitionDal(JumperDbContext context) : base(context)
    {
    }
}
