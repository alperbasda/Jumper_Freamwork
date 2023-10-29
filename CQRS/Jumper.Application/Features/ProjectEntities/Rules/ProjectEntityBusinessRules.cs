using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Helpers;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectEntities.Rules;

public class ProjectEntityBusinessRules : BaseBusinessRules
{
    private readonly IProjectDeclarationDal _projectDeclarationDal;
    private readonly IProjectEntityDal _projectEntityDal;

    public ProjectEntityBusinessRules(TokenParameters tokenParameters, IProjectDeclarationDal projectDeclarationDal, IProjectEntityDal projectEntityDal) : base(tokenParameters)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _projectEntityDal = projectEntityDal;
    }

    public async Task ThrowExceptionIfProjectDeclarationUserNotLoggedUser(Guid projectDeclarationId)
    {
        if (TokenParameters.IsSuperUser || await _projectDeclarationDal.AnyAsync(e => e.UserId == TokenParameters.UserId && e.Id == projectDeclarationId))
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
    }

    public async Task ThrowExceptionIfSamaNameProjectEntityExists(Guid projectDeclarationId, string name)
    {
        if (await _projectEntityDal.AnyAsync(x => x.Name == name && x.ProjectDeclarationId == projectDeclarationId))
        {
            throw new BusinessException("Aynı isimde nesne daha önce kayıt edilmiş.");
        }
    }

    public async Task ThrowExceptionIfSamaNameProjectEntityExistsForUpdate(Guid projectDeclarationId, string name, Guid id)
    {
        if (await _projectEntityDal.AnyAsync(w => w.ProjectDeclarationId == projectDeclarationId && w.Name == name && w.Id != id))
        {
            throw new BusinessException("Aynı isimde nesne daha önce kayıt edilmiş.");
        }
    }

    public async Task<ProjectEntity> CloneObject(Guid entityDefinitionId)
    {
        var data = await _projectEntityDal.GetAsync(w => w.Id == entityDefinitionId, include: w => w.Include(q => q.Properties));
        await this.ThrowExceptionIfDataNull(data);
        var returnData = new ProjectEntity
        {
            Id = Guid.NewGuid(),
            CreatedTime = DateTime.UtcNow,
            UpdatedTime = null,
            DeletedTime = null,
            ProjectDeclarationId = data!.ProjectDeclarationId,
            DatabaseType = data.DatabaseType,
            Name = data.Name,
            Properties = new List<ProjectEntityProperty>()
        };

        if (!data.Properties.Any())
        {
            return returnData;
        }

        foreach (var item in data!.Properties)
        {
            returnData.Properties.Add(new ProjectEntityProperty
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                ProjectEntityId = item.ProjectEntityId,
                PropertyTypeCode = item.PropertyTypeCode,
                PropertyInputTypeCode = item.PropertyInputTypeCode,
                Name = item.Name,
                Order = item.Order,
                UpdatedTime = null,
                DeletedTime = null
            });
        }

        return returnData;
    }


    public void AddDefaultProperties(ProjectEntity projectEntity)
    {
        if (projectEntity.Properties == null)
            projectEntity.Properties = new List<ProjectEntityProperty>();


        projectEntity.Properties.Add(new ProjectEntityProperty {Id = Guid.NewGuid(), Name = "Id", PropertyTypeCode = "Guid", Order = 0, PropertyInputTypeCode = PropertyCreatorHelper.HIDDEN_INPUT_TYPE});

        projectEntity.Properties.Add(new ProjectEntityProperty {Id = Guid.NewGuid(), Name = "CreatedTime", PropertyTypeCode = "DateTime", Order = 10001, PropertyInputTypeCode = PropertyCreatorHelper.DONT_USE_INPUT_TYPE });

        projectEntity.Properties.Add(new ProjectEntityProperty {Id = Guid.NewGuid(), Name = "UpdatedTime", PropertyTypeCode = "DateTime?", Order = 10002, PropertyInputTypeCode = PropertyCreatorHelper.DONT_USE_INPUT_TYPE });

        projectEntity.Properties.Add(new ProjectEntityProperty { Id = Guid.NewGuid(), Name = "DeletedTime", PropertyTypeCode = "DateTime?",Order = 10003, PropertyInputTypeCode = PropertyCreatorHelper.DONT_USE_INPUT_TYPE });
    }


    public void SetIds(ProjectEntity projectEntity)
    {
        projectEntity.Id = Guid.NewGuid();
        foreach (var property in projectEntity.Properties)
        {
            property.ProjectEntityId = projectEntity.Id;
            property.Id = Guid.NewGuid();
        }
    }



}
