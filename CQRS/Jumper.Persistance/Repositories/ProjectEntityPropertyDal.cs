using Core.Persistence.Repositories;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Persistance.Contexts;

namespace Jumper.Persistance.Repositories;

public class ProjectEntityPropertyDal : EfRepositoryBase<ProjectEntityProperty, Guid, JumperDbContext>, IProjectEntityPropertyDal
{
    public ProjectEntityPropertyDal(JumperDbContext context) : base(context)
    {
    }
}
