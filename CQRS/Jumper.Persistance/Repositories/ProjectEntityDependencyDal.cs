using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class ProjectEntityDependencyDal : EfRepositoryBase<ProjectEntityDependency, Guid, JumperDbContext>, IProjectEntityDependencyDal
{
    public ProjectEntityDependencyDal(JumperDbContext context) : base(context)
    {
    }
}
