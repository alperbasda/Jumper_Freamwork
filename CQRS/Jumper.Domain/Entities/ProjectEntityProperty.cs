using Core.Persistence.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jumper.Domain.Entities;

public class ProjectEntityProperty : Entity<Guid>
{
    public Guid ProjectEntityId { get; set; }

    public virtual ProjectEntity ProjectEntity { get; set; }

    public string PropertyTypeCode { get; set; }

    public string PropertyInputTypeCode { get; set; }

    public string Name { get; set; }

    public int Order { get; set; }

    [InverseProperty("ProjectEntityProperty")]
    public virtual ICollection<ProjectEntityActionProperty> Metods { get; set; }

    public virtual ICollection<EntityPropertyFeatureDefinitionProjectEntityPropertyRelation> EntityPropertyFeatureDefinitionProjectEntityPropertyRelations { get; set; }

}
