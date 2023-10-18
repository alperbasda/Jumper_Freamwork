using Core.Persistence.Repositories;
using Jumper.Domain.MongoEntities;

namespace Jumper.Application.Services.Repositories;

public interface IArchitectureDefinitionDal : IAsyncRepository<ArchitectureDefinition, Guid>
{
}
