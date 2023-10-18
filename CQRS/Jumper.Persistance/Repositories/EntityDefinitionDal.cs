using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class EntityDefinitionDal : EfRepositoryBase<EntityDefinition, Guid, JumperDbContext>, IEntityDefinitionDal
{
    public EntityDefinitionDal(JumperDbContext context) : base(context)
    {
    }
}
