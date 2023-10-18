using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class ProjectEntityDal : EfRepositoryBase<ProjectEntity, Guid, JumperDbContext>, IProjectEntityDal
{
    public ProjectEntityDal(JumperDbContext context) : base(context)
    {
    }
}
