using System.ComponentModel;

namespace Jumper.Domain.Enums;

public enum PropertyPocoType
{
    [Description("Gösterme")]
    Hidden = 0,
    [Description("Dropdown")]
    DropDown = 1,
    [Description("Input")]
    Input = 2
}
