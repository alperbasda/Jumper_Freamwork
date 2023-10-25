using Jumper.Domain.Entities;
using Jumper.Domain.Enums;
using Jumper.Common.StringHelpers;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Newtonsoft.Json.Linq;

namespace Jumper.Application.Helpers;

public static class PropertyCreatorHelper
{
    public const string RELATIONAL_INPUT_TYPE = "relational_dropdown";
    public const string DROPDOWN_INPUT_TYPE = "dropdown";
    public const string TEXT_INPUT_TYPE = "text";
    public const string FILE_INPUT_TYPE = "file";
    public const string TEXTAREA_INPUT_TYPE = "textarea";
    public const string DATE_INPUT_TYPE = "date";
    public const string DATETIME_INPUT_TYPE = "datetime";
    public const string NUMBER_INPUT_TYPE = "number";
    public const string HIDDEN_INPUT_TYPE = "hidden";
    public const string DONT_USE_INPUT_TYPE = "dont_use";

    /// <summary>
    /// Persistence serviste context lazy kalkarken dolar.
    /// </summary>
    public static List<PropertyInputTypeDeclaration>? PropertyInputTypeDeclarations;

    /// <summary>
    /// ProjectEntityPropertyi veya ProjectEntityActionPropertyi jobject olarak alır html tag döner.
    /// </summary>
    /// <param name="property"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="BusinessException"></exception>
    public static string ToHtmlTag(JToken property,string entityName)
    {
        var inputType = PropertyInputTypeDeclarations!.FirstOrDefault(w => w.Code == property["PropertyInputTypeCode"]!.Value<string>());
        if (inputType == null)
        {
            return "";
        }

        return inputType.Template.Replace("$[Name]", property["PropertyName"]!.Value<string>()).Replace("$[EntityName]", entityName);
    }

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
                PropertyInputTypeCode = RELATIONAL_INPUT_TYPE,
                IsShowOnRelation = false,
                Order = 1001,
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
                PropertyInputTypeCode = RELATIONAL_INPUT_TYPE,
                IsShowOnRelation = false,
                Order = 10001,
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
                PropertyInputTypeCode = DONT_USE_INPUT_TYPE,
                IsShowOnRelation = false,
                Order = 10001,
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
            PropertyInputTypeCode = DONT_USE_INPUT_TYPE,
            IsShowOnRelation = false,
            Order = 10001,
        });

        return returnList;
    }

}
