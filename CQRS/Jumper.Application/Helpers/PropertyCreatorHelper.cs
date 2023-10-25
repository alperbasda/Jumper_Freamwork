using Jumper.Domain.Entities;
using Jumper.Domain.Enums;
using Jumper.Common.StringHelpers;

namespace Jumper.Application.Helpers;

public static class PropertyCreatorHelper
{
    public const string RELATIONAL_INPUT_TYPE = "relational_dropdown";
    public const string DROPDOWN_INPUT_TYPE = "dropdown";
    public const string TEXT_INPUT_TYPE = "text";
    public const string TEXTAREA_INPUT_TYPE = "textarea";
    public const string DATE_INPUT_TYPE = "date";
    public const string DATETIME_INPUT_TYPE = "datetime";
    public const string NUMBER_INPUT_TYPE = "number";
    public const string HIDDEN_INPUT_TYPE = "hidden";

    public static List<ProjectEntityProperty> GetNewPropertiesIfRelationalDb(ProjectEntity entity, ProjectEntity oppositeEntity, bool IsDepended = true)
    {
        var returnList = new List<ProjectEntityProperty>();
        if (entity.DatabaseType == DatabaseType.Mongo)
            return returnList;
        if (IsDepended)
        {
            returnList.Add(new ProjectEntityProperty
            {
                Id = Guid.NewGuid(),
                ProjectEntityId = oppositeEntity.Id,
                CreatedTime = DateTime.Now,
                UpdatedTime = null,
                DeletedTime = null,
                IsUnique = false,
                IsConstant = true,
                PropertyTypeCode = "Guid",
                Name = $"{entity.Name}Id",
                Prefix = "",
                HasIndex = false,
                PropertyInputTypeCode = RELATIONAL_INPUT_TYPE
            });
            returnList.Add(new ProjectEntityProperty
            {
                Id = Guid.NewGuid(),
                ProjectEntityId = oppositeEntity.Id,
                CreatedTime = DateTime.Now,
                UpdatedTime = null,
                DeletedTime = null,
                IsUnique = false,
                IsConstant = true,
                PropertyTypeCode = entity.Name,
                Name = entity.Name,
                Prefix = "virtual",
                HasIndex = false,
                PropertyInputTypeCode = RELATIONAL_INPUT_TYPE
            });
        }
        else
        {
            returnList.Add(new ProjectEntityProperty
            {
                Id = Guid.NewGuid(),
                ProjectEntityId = oppositeEntity.Id,
                CreatedTime = DateTime.Now,
                UpdatedTime = null,
                DeletedTime = null,
                IsUnique = false,
                IsConstant = true,
                PropertyTypeCode = $"ICollection<{entity.Name}>",
                Name = entity.Name.ToPlural(),
                Prefix = "virtual",
                HasIndex = false,
                PropertyInputTypeCode = HIDDEN_INPUT_TYPE
            });
        }
        return returnList;
    }

    public static List<ProjectEntityProperty> GetNewPropertiesIfNoSqlDb(ProjectEntity entity, ProjectEntity oppositeEntity, bool IsDepended = true)
    {
        var returnList = new List<ProjectEntityProperty>();
        if (IsDepended || entity.DatabaseType != DatabaseType.Mongo)
            return returnList;

        returnList.Add(new ProjectEntityProperty
        {
            Id = Guid.NewGuid(),
            ProjectEntityId = oppositeEntity.Id,
            CreatedTime = DateTime.Now,
            UpdatedTime = null,
            DeletedTime = null,
            IsUnique = false,
            IsConstant = true,
            PropertyTypeCode = $"List<{entity.Name}>",
            Name = entity.Name,
            Prefix = string.Empty,
            HasIndex = false,
            PropertyInputTypeCode = HIDDEN_INPUT_TYPE
        });

        return returnList;
    }

}
