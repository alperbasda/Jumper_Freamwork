using Core.CrossCuttingConcerns.Helpers.EnumHelpers;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace Jumper.Domain.Enums;

public enum NoSqlDatabaseType
{
    [Description("Mongo")]
    Mongo
}

public enum RelationalDatabaseType
{
    [Description("MsSql")]
    MsSql,
    [Description("PostgreSql")]
    PostgreSql,
    [Description("MySql")]
    MySql,
    [Description("SqlLite")]
    SqlLite
}

public enum DatabaseType
{
    [Description("MsSql")]
    MsSql,
    [Description("PostgreSql")]
    PostgreSql,
    [Description("MySql")]
    MySql,
    [Description("SqlLite")]
    SqlLite,
    [Description("Mongo")]
    Mongo
}

public static class DatabaseTypeExtension
{
    public static DatabaseType ToDatabaseType(this RelationalDatabaseType type)
    {
        return type.GetDescription().ToEnum<DatabaseType>();
    }

    public static DatabaseType ToDatabaseType(this NoSqlDatabaseType type)
    {
        return type.GetDescription().ToEnum<DatabaseType>();
    }

    public static IEnumerable<DatabaseType> GetRelationDatabaseTypes()
    {
        foreach (RelationalDatabaseType type in (RelationalDatabaseType[])Enum.GetValues(typeof(RelationalDatabaseType)))
        {
            yield return type.ToDatabaseType();
        }
    }
    public static IEnumerable<DatabaseType> GetNoSqlDatabaseTypes()
    {
        foreach (NoSqlDatabaseType type in (NoSqlDatabaseType[])Enum.GetValues(typeof(NoSqlDatabaseType)))
        {
            yield return type.ToDatabaseType();
        }
    }
}
