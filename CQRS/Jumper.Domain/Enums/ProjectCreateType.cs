using System.ComponentModel;

namespace Jumper.Domain.Enums;

public enum ProjectCreateType
{
    [Description("Bilinmiyor")]
    Unknown,
    [Description("Cqrs")]
    Cqrs,
    [Description("Katmanlı Mimari")]
    NLayer
}
