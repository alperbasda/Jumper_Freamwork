using Core.Persistence.Models;
using Jumper.Domain.Base;
using Jumper.Domain.Enums;

namespace Jumper.Domain.Entities;

public class EntityPropertyDefinition : Entity<Guid>, IConstantEntity
{
    public Guid EntityDefinitionId { get; set; }

    public virtual EntityDefinition EntityDefinition { get; set; }

    public string PropertyTypeCode { get; set; }

    public string Name { get; set; }

    public bool HasIndex { get; set; }

    public bool IsUnique { get; set; }

    public bool IsConstant { get; set; } = false;
}
