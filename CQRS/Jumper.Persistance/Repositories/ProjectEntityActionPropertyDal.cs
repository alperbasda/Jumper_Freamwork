using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class ProjectEntityActionPropertyDal : EfRepositoryBase<ProjectEntityActionProperty, Guid, JumperDbContext>, IProjectEntityActionPropertyDal
{
    public ProjectEntityActionPropertyDal(JumperDbContext context) : base(context)
    {
    }
}
