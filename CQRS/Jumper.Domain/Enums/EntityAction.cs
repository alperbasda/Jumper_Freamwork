using System.ComponentModel;

namespace Jumper.Domain.Enums;

public enum EntityAction
{
    [Description("Ekle")]
    Create,
    [Description("Toplu Ekle")]
    BulkCreate,
    [Description("Güncelle")]
    Update,
    [Description("Toplu Güncelle")]
    BulkUpdate,
    [Description("Sil")]
    Delete,
    [Description("Toplu Sil")]
    BulkDelete,
    [Description("Getir")]
    Get,
    [Description("Listele")]
    GetList
}
