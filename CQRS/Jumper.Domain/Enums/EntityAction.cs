using System.ComponentModel;

namespace Jumper.Domain.Enums;

public enum EntityAction
{
    [Description("Ekle")]
    Create = 0,
    [Description("Toplu Ekle")]
    BulkCreate = 1,
    [Description("Güncelle")]
    Update = 2,
    [Description("Toplu Güncelle")]
    BulkUpdate = 3,
    [Description("Sil")]
    Delete = 4,
    [Description("Getir")]
    Get = 5,
    [Description("Listele")]
    GetList = 6
}
