using Core.Persistence.Repositories;
using Jumper.Domain.Entities;

namespace Jumper.Application.Services.Repositories;

public interface IProjectEntityPropertyDal : IAsyncRepository<ProjectEntityProperty,Guid>
{
}
