using System.ComponentModel;

namespace Jumper.Domain.Enums;

public enum ProjectStatus
{
    [Description("Hazırlanıyor")]
    Preparing,
    [Description("Oluşturma Kuyruğunda")]
    WaitingGenerate,
    [Description("Dosyalar Oluşturuluyor")]
    Generating,
    [Description("İndirilebilir")]
    Downloadable,

}
