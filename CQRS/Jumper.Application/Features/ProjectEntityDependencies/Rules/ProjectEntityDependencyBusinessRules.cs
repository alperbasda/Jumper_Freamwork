using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;
using Jumper.Application.Helpers;
using Jumper.Application.Services.Repositories;
using Jumper.CodeGenerator.Helpers.StringHelpers;
using Jumper.Domain.Entities;
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityDependencies.Rules;

public class ProjectEntityDependencyBusinessRules : BaseBusinessRules
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly IProjectEntityPropertyDal _projectEntityPropertyDal;
    private readonly IProjectDeclarationDal _projectDeclarationDal;
    private readonly IProjectEntityDependencyDal _projectEntityDependencyDal;

    public ProjectEntityDependencyBusinessRules(TokenParameters tokenParameters, IProjectEntityDal projectEntityDal, IProjectEntityDependencyDal projectEntityDependencyDal, IProjectDeclarationDal projectDeclarationDal, IProjectEntityPropertyDal projectEntityPropertyDal) : base(tokenParameters)
    {
        _projectEntityDal = projectEntityDal;
        _projectEntityDependencyDal = projectEntityDependencyDal;
        _projectDeclarationDal = projectDeclarationDal;
        _projectEntityPropertyDal = projectEntityPropertyDal;
    }

    public async Task ThrowExceptionIfProjectDeclarationUserNotLoggedUser(Guid projectDeclarationId)
    {
        if (TokenParameters.IsSuperUser || await _projectDeclarationDal.AnyAsync(e => e.UserId == TokenParameters.UserId && e.Id == projectDeclarationId))
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
    }

    public void ThrowExceptionIfProjectEntityUserNotLoggedUser(List<ProjectEntity> entities)
    {
        if (!TokenParameters.IsSuperUser && entities.Any(w => w.UserId != TokenParameters.UserId))
        {
            throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
        }
    }
    public async Task ThrowExceptionIfProjectEntityDependencyAddedBefore(CreateProjectEntityDependencyCommand request)
    {
        var result = await _projectEntityDependencyDal.AnyAsync(
            e => (e.DependsOnId == request.DependsOnId && e.DependedId == request.DependedId) ||
            (e.DependsOnId == request.DependedId && e.DependedId == request.DependsOnId)
            );
        if (result)
        {
            throw new BusinessException("İlişki Önceden Eklenmiş.");
        }
    }


    public async Task<List<ProjectEntity>> GetRelatedEntities(Guid dependedId, Guid dependsOnId)
    {
        var relatedEntities = (await _projectEntityDal.GetListAsync(w => w.Id == dependsOnId || w.Id == dependedId)).Items;
        if (relatedEntities.Count != 2)
        {
            throw new BusinessException("2 ayrı entity üzerinde ilişki kurabilirisiniz.");
        }
        if (relatedEntities.Select(w => w.DatabaseType).Distinct().Count() != 1)
        {
            throw new BusinessException("Farklı tip veritabanları arasında ilişki kuramazsınız.");
        }
        return relatedEntities.ToList();
    }

    public async Task CreateRelationTableIfRelationIsNToN(List<ProjectEntity> relatedEntities, EntityDependencyType type)
    {
        if (type != EntityDependencyType.ManyToMany)
            return;

        var tableName = $"{string.Join("", relatedEntities.Select(w => w.Name).OrderBy(w => w))}Relation";
        var createEntity = new ProjectEntity
        {
            Id = Guid.NewGuid(),
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            DeletedTime = null,
            DatabaseType = relatedEntities.First().DatabaseType,
            Name = tableName,
            ProjectDeclarationId = relatedEntities.First().ProjectDeclarationId,
            UserId = relatedEntities.First().UserId,
            Properties = new List<ProjectEntityProperty>
            {
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = relatedEntities.First().Name,
                    Name = relatedEntities.First().Name,
                    Prefix = relatedEntities.First().DatabaseType == DatabaseType.Mongo ? "" : "virtual"
                },
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = relatedEntities.Last().Name,
                    Name = relatedEntities.Last().Name,
                    Prefix = relatedEntities.First().DatabaseType == DatabaseType.Mongo ? "" : "virtual"
                },

                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = "Guid",
                    Name = $"{relatedEntities.First().Name}Id",
                    Prefix = string.Empty,
                },
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = "Guid",
                    Name = $"{relatedEntities.Last().Name}Id",
                    Prefix = string.Empty,
                },
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = "DateTime",
                    Name = "CreatedTime",
                    Prefix = string.Empty,
                },
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = "DateTime?",
                    Name = "UpdatedTime",
                    Prefix = string.Empty,
                },
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = "DateTime?",
                    Name = "DeletedTime",
                    Prefix = string.Empty,
                },
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    IsConstant = true,
                    PropertyTypeCode = "Guid",
                    Name = "Id",
                    Prefix = string.Empty,
                }
            },
            IsConstant = true,
        };


        _ = await _projectEntityDal.AddAsync(createEntity);
    }

    public async Task CreateRelationProperties(List<ProjectEntity> relatedEntities, EntityDependencyType type, Guid dependedId)
    {
        var createList = new List<ProjectEntityProperty>();
        if (type == EntityDependencyType.ManyToMany)
        {
            var mockProjectEntity = new ProjectEntity { Name = StringHelper.GetRelationTableName(relatedEntities.Select(w => w.Name).ToArray()), DatabaseType = relatedEntities.First().DatabaseType };
            foreach (var item in relatedEntities)
            {
                createList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfNoSqlDb(mockProjectEntity, item, false));
                createList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfRelationalDb(mockProjectEntity, item, false));
            }
        }
        else if (type == EntityDependencyType.OneToMany)
        {
            foreach (var item in relatedEntities)
            {
                var oppositeEntity = relatedEntities.First(w => w.Id != item.Id);
                createList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfNoSqlDb(item, oppositeEntity, item.Id == dependedId));
                createList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfRelationalDb(item, oppositeEntity, item.Id == dependedId));
            }

        }
        else if (type == EntityDependencyType.OneToOne)
        {
            foreach (var item in relatedEntities)
            {
                var oppositeEntity = relatedEntities.First(w => w.Id != item.Id);
                createList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfNoSqlDb(item, oppositeEntity, true));
                createList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfRelationalDb(item, oppositeEntity, true));
            }
        }

        if (createList.Any())
        {
            await _projectEntityPropertyDal.AddRangeAsync(createList);
        }
    }

    public async Task DeleteRelationTableIfRelationIsNToN(ProjectEntityDependency command)
    {
        if (command.EntityDependencyType != EntityDependencyType.ManyToMany)
            return;

        var relatedEntities = await _projectEntityDal.GetListAsync(w => w.Id == command.DependedId || w.Id == command.DependsOnId);
        if (relatedEntities.Count != 2)
        {
            throw new BusinessException("Relation Table Could Not Be Create.");
        }
        string tableName = $"{string.Join("", relatedEntities.Items.Select(w => w.Name).OrderBy(w => w))}Relation";
        var data = await _projectEntityDal.GetAsync(w => w.Name == tableName && w.UserId == relatedEntities.Items.First().UserId);

        if (data == null)
        {
            throw new NotFoundException("Relation Table Could Not Be Found.");
        }
        _ = await _projectEntityDal.DeleteAsync(data);
    }

    public async Task DeleteRelationProperties(List<ProjectEntity> relatedEntities, EntityDependencyType type, Guid dependedId)
    {
        var deleteList = new List<ProjectEntityProperty>();
        if (type == EntityDependencyType.ManyToMany)
        {
            var mockProjectEntity = new ProjectEntity { Name = StringHelper.GetRelationTableName(relatedEntities.Select(w => w.Name).ToArray()) };
            foreach (var item in relatedEntities)
            {
                deleteList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfNoSqlDb(mockProjectEntity, item, false));
            }
        }
        else if (type == EntityDependencyType.OneToMany)
        {
            foreach (var item in relatedEntities)
            {
                var oppositeEntity = relatedEntities.First(w => w.Id != item.Id);
                deleteList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfNoSqlDb(item, oppositeEntity, item.Id == dependedId));
                deleteList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfRelationalDb(item, oppositeEntity, item.Id == dependedId));
            }

        }
        else if (type == EntityDependencyType.OneToOne)
        {
            foreach (var item in relatedEntities)
            {
                var oppositeEntity = relatedEntities.First(w => w.Id != item.Id);
                deleteList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfNoSqlDb(item, oppositeEntity, true));
                deleteList.AddRange(PropertyCreatorHelper.GetNewPropertiesIfRelationalDb(item, oppositeEntity, true));
            }
        }

        if (deleteList.Any())
        {
            var dataNames = deleteList.Select(w => w.Name).ToList();
            var entityIds = relatedEntities.Select(w => w.Id).ToList();

            var deleteDatas = await _projectEntityPropertyDal.GetListAsync(w => dataNames.Contains(w.Name) && entityIds.Contains(w.ProjectEntityId));
            if (deleteDatas.Items.Any())
            {
                await _projectEntityPropertyDal.DeleteRangeAsync(deleteDatas.Items);
            }

        }
    }

}
