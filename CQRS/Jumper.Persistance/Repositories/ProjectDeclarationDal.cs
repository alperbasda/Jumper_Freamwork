using Core.Persistence.Models;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.MongoEntities;
using MongoDbAdapter.Repository;

namespace Jumper.Persistance.Repositories
{
    public class ProjectDeclarationDal : MongoRepositoryBase<ProjectDeclaration, Guid>, IProjectDeclarationDal
    {
        public ProjectDeclarationDal(DatabaseOptions settings) : base(settings)
        {
        }
    }
}
