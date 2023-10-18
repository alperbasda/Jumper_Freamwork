using Core.Persistence.Models;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.MongoEntities;
using MongoDbAdapter.Repository;

namespace Jumper.Persistance.Repositories;

public class ArchitectureDefinitionDal : MongoRepositoryBase<ArchitectureDefinition, Guid>, IArchitectureDefinitionDal
{
    public ArchitectureDefinitionDal(DatabaseOptions settings) : base(settings)
    {
    }
}
