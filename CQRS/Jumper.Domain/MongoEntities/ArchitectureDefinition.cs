using Core.Persistence.Models;

namespace Jumper.Domain.MongoEntities;

public class ArchitectureDefinition : MongoEntity<Guid>
{
    public ArchitectureDefinition()
    {
        Projects = new List<ArchitectureProjectDefinition>();
    }

    public string Name { get; set; }

    public string DllName { get; set; }

    public List<ArchitectureProjectDefinition> Projects { get; set; }
}
