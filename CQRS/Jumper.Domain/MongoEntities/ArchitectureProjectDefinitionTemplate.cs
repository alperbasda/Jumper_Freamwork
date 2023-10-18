using Core.Persistence.Models;

namespace Jumper.Domain.MongoEntities;

public class ArchitectureProjectDefinitionTemplate : MongoEntity<Guid>
{
    public string? Folder { get; set; }

    public string Name { get; set; }

    public string Template { get; set; }

    public string Processor { get; set; }
}
