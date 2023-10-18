using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.Domain.MongoEntities;

namespace Jumper.CodeGenerator.BuilderBase.ArchitectureCreators;

public interface IArchitectureCreator
{
    void Create(GetWithAllDetailByIdProjectDeclarationResponse project, ArchitectureDefinition architectureDefinition);
}
