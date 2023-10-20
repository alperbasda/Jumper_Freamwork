using Core.Persistence.Models;

namespace Jumper.Domain.MongoEntities;

public class ArchitectureProjectDefinition : MongoEntity<Guid>
{
    public string Name { get; set; }

    public string DotnetType { get; set; }

    public string Folder { get; set; }
}
