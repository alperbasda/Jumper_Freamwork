using Jumper.CodeGenerator.Helpers.StringHelpers;
using Jumper.Domain.Entities;
using Jumper.Domain.Enums;

namespace Jumper.Application.Helpers;

public static class PropertyCreatorHelper
{
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
                HasIndex = false
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
                HasIndex = false
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
                HasIndex = false
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
            PropertyTypeCode = $"List<{entity.Name.ToPlural()}>",
            Name = entity.Name,
            Prefix = string.Empty,
            HasIndex = false
        });

        return returnList;
    }

}
