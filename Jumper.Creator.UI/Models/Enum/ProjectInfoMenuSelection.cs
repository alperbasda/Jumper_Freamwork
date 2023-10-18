using System.ComponentModel;

namespace Jumper.Creator.UI.Models.Enum
{
    public enum ProjectInfoMenuSelection
    {
        [Description("Genel Bilgiler")]
        Info,
        [Description("Cache Ayarları")]
        Cache,
        [Description("NoSql Ayarları")]
        NoSqlDatabase,
        [Description("Relational Db Ayarları")]
        RelationalDatabase,
        [Description("Log Ayarları")]
        Log,
        [Description("RabbitMq Ayarları")]
        RabbitMq
    }

    public enum ProjectInfoStickyMenuSelection
    {
        [Description("Nesne Listesi")]
        EntityList,
        [Description("Nesne Özellikleri")]
        EntityPropertyList,
        [Description("Nesne İlişkileri")]
        EntityRelationList,
        [Description("Metotlar")]
        EntityActionList
    }

}
