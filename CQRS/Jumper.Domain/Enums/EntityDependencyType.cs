using System.ComponentModel;

namespace Jumper.Domain.Enums;

public enum EntityDependencyType
{
    [Description("1-1")]
    OneToOne,
    [Description("1-N")]
    OneToMany,
    [Description("N-N")]
    ManyToMany
}
