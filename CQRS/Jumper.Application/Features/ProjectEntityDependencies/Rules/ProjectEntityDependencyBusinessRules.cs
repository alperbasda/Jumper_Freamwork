using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Features.ProjectEntityDependencies.Commands.Create;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Domain.Enums;

namespace Jumper.Application.Features.ProjectEntityDependencies.Rules;

public class ProjectEntityDependencyBusinessRules : BaseBusinessRules
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly IProjectDeclarationDal _projectDeclarationDal;
    private readonly IProjectEntityDependencyDal _projectEntityDependencyDal;

    public ProjectEntityDependencyBusinessRules(TokenParameters tokenParameters, IProjectEntityDal projectEntityDal, IProjectEntityDependencyDal projectEntityDependencyDal, IProjectDeclarationDal projectDeclarationDal) : base(tokenParameters)
    {
        _projectEntityDal = projectEntityDal;
        _projectEntityDependencyDal = projectEntityDependencyDal;
        _projectDeclarationDal = projectDeclarationDal;

    }

    public async Task ThrowExceptionIfProjectDeclarationUserNotLoggedUser(Guid projectDeclarationId)
    {
        if (TokenParameters.IsSuperUser || await _projectDeclarationDal.AnyAsync(e => e.UserId == TokenParameters.UserId && e.Id == projectDeclarationId))
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
    }

    public async Task ThrowExceptionIfProjectEntityUserNotLoggedUser(Guid leftProjectEntityId, Guid rightProjectEntityId)
    {
        var leftResult = await _projectEntityDal.AnyAsync(e => e.Id == leftProjectEntityId && e.UserId == TokenParameters.UserId);
        var rightResult = await _projectEntityDal.AnyAsync(e => e.Id == rightProjectEntityId && e.UserId == TokenParameters.UserId);

        if (TokenParameters.IsSuperUser || (rightResult && leftResult))
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
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

    public void ThrowExceptionIfProjectEntityDependencyCircular(CreateProjectEntityDependencyCommand request)
    {
        if (request.DependsOnId == request.DependedId)
        {
            throw new BusinessException("Şimdilik Döngüsel İlişki Türünü Destekleyemiyoruz.");
        }
    }

    public async Task CreateRelationTableIfRelationIsNToN(CreateProjectEntityDependencyCommand command)
    {
        if (command.EntityDependencyType != EntityDependencyType.ManyToMany)
            return;

        var relatedEntities = await _projectEntityDal.GetListAsync(w => w.Id == command.DependedId || w.Id == command.DependsOnId);
        if (relatedEntities.Count != 2)
        {
            throw new BusinessException("Relation Table Could Not Be Create.");
        }

        var tableName = $"{string.Join("", relatedEntities.Items.Select(w => w.Name).OrderBy(w => w))}Relation";
        var createEntity = new ProjectEntity
        {
            Id = Guid.NewGuid(),
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
            DeletedTime = null,
            DatabaseType = relatedEntities.Items.First().DatabaseType,
            Name = tableName,
            ProjectDeclarationId = command.ProjectDeclarationId,
            UserId = relatedEntities.Items.First().UserId,
            Properties = new List<ProjectEntityProperty>
            {
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    PropertyTypeCode = "Guid",
                    Name = $"{relatedEntities.Items.First().Name}Id",
                },
                new ProjectEntityProperty
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    DeletedTime = null,
                    IsUnique = false,
                    PropertyTypeCode = "Guid",
                    Name = $"{relatedEntities.Items.Last().Name}Id",
                }
            },
            IsConstant = true,
        };
        

        _ = await _projectEntityDal.AddAsync(createEntity);
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
            throw new NotFoundException("Relation Table Could Not Be Delete.");
        }
        _ = await _projectEntityDal.DeleteAsync(data);

    }

}
