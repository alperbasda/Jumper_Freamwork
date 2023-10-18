using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jumper.Application.Features.ProjectEntities.Rules;

public class ProjectEntityBusinessRules : BaseBusinessRules
{
    private readonly IEntityDefinitionDal _entityDefinitionDal;
    private readonly IProjectDeclarationDal _projectDeclarationDal;
    private readonly IProjectEntityDal _projectEntityDal;

    public ProjectEntityBusinessRules(TokenParameters tokenParameters, IEntityDefinitionDal entityDefinitionDal, IProjectDeclarationDal projectDeclarationDal, IProjectEntityDal projectEntityDal) : base(tokenParameters)
    {
        _entityDefinitionDal = entityDefinitionDal;
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

    public async Task<EntityDefinition> GetDefinitionWithProperties(Guid entityDefinitionId)
    {
        var data = await _entityDefinitionDal.GetAsync(w => w.Id == entityDefinitionId, include: w => w.Include(q => q.EntityPropertyDefinitions));

        await this.ThrowExceptionIfDataNull(data);

        return data!;
    }

    public void AddDefaultProperties(ProjectEntity projectEntity)
    {
        projectEntity.Properties.Add(new ProjectEntityProperty { Id = Guid.NewGuid(), Name = "Id", PropertyTypeCode = "Guid", IsUnique = false, HasIndex = false });
        projectEntity.Properties.Add(new ProjectEntityProperty { Id = Guid.NewGuid(), Name = "CreatedTime", PropertyTypeCode = "DateTime", IsUnique = false, HasIndex = false });
        projectEntity.Properties.Add(new ProjectEntityProperty { Id = Guid.NewGuid(), Name = "UpdatedTime", PropertyTypeCode = "DateTime?", IsUnique = false, HasIndex = false });
        projectEntity.Properties.Add(new ProjectEntityProperty { Id = Guid.NewGuid(), Name = "DeletedTime", PropertyTypeCode = "DateTime?", IsUnique = false, HasIndex = true });
    }

}
