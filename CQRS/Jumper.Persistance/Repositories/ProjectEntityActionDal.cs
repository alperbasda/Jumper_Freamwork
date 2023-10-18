using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class ProjectEntityActionDal : EfRepositoryBase<ProjectEntityAction, Guid, JumperDbContext>, IProjectEntityActionDal
{
    public ProjectEntityActionDal(JumperDbContext context) : base(context)
    {
    }
}
