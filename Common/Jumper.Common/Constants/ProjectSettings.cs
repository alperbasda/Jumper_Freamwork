namespace Jumper.Common.Constants;

//Tasarımları ilgilendiren static bilgiler bu sayfada bulunacak.
/// <summary>
/// EntityAction Enum u ile bağlantılıdır değiştirirken dikkat ediniz.
/// </summary>
public static class ProjectSettings
{
    public static string[] RequestExculededProperties = new[] { "DeletedTime", "UpdatedTime", "CreatedTime" };

    public static string[] EntityExculededProperties = new[] { "DeletedTime", "UpdatedTime", "CreatedTime", "Id" };

    public static string[] CudActionTypes = new[] { "0", "1", "2", "3", "4" };

    public static string[] BulkCudActionTypes = new[] { "1",  "3" };

    public static string[] SingleCudActionTypes = new[] { "0", "2", "4" };

    public static string[] ReadActionTypes = new[] { "5", "6" };

    public static string[] NoSqlDatabaseTypes = new[] { "4" };

    public static string[] RelationalDatabaseTypes = new[] { "0", "1", "2", "3" };
}
