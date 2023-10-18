using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using System.Linq.Expressions;

namespace Jumper.Application.Features.EntityDefinitions.Rules;

public class EntityDefinitionBusinessRules : BaseBusinessRules
{
    IEntityDefinitionDal _entityDefinitionDal;
    IEntityPropertyDefinitionDal _entityPropertyDefinitionDal;

    public EntityDefinitionBusinessRules(IEntityDefinitionDal entityDefinitionDal, TokenParameters tokenParameters, IEntityPropertyDefinitionDal entityPropertyDefinitionDal) : base(tokenParameters)
    {
        _entityDefinitionDal = entityDefinitionDal;
        _entityPropertyDefinitionDal = entityPropertyDefinitionDal;
    }

    public async Task ThrowExceptionIfSameNamedDataExists(EntityDefinition entityDefinition)
    {
        if (await _entityDefinitionDal.AnyAsync(w => w.Name == entityDefinition.Name && w.UserId == entityDefinition.UserId))
        {
            throw new BusinessException(entityDefinition.Name + " adında nesne daha önce kayıt edilmiş.");
        }

    }

    public async Task ThrowExceptionIfSameNamedDataExistsForUpdate(EntityDefinition entityDefinition)
    {
        if (await _entityDefinitionDal.AnyAsync(w => w.Name == entityDefinition.Name && entityDefinition.Id != entityDefinition.Id))
        {
            throw new BusinessException(entityDefinition.Name + " adında nesne daha önce kayıt edilmiş.");
        }
    }

    public Expression<Func<EntityDefinition, bool>>? GetUserIdExpressionIfUserNotSuperUser()
    {
        return TokenParameters.IsSuperUser ? null : w => w.UserId == TokenParameters.UserId;
    }

    public async Task AddDefaultProperties(Guid entityDefinitionId)
    {
        var list = new List<EntityPropertyDefinition>
        {
        new EntityPropertyDefinition { Id = Guid.NewGuid(),CreatedTime = DateTime.Now,EntityDefinitionId = entityDefinitionId,HasIndex = false,IsUnique = false,Name = "Id",PropertyTypeCode = "Guid", IsConstant = true },
        new EntityPropertyDefinition { Id = Guid.NewGuid(),CreatedTime = DateTime.Now,EntityDefinitionId = entityDefinitionId,HasIndex = false,IsUnique = false,Name = "CreatedTime",PropertyTypeCode = "DateTime",IsConstant = true },
        new EntityPropertyDefinition { Id = Guid.NewGuid(),CreatedTime = DateTime.Now,EntityDefinitionId = entityDefinitionId,HasIndex = false,IsUnique = false,Name = "UpdatedTime",PropertyTypeCode = "DateTime?",IsConstant = true },
        new EntityPropertyDefinition { Id = Guid.NewGuid(),CreatedTime = DateTime.Now,EntityDefinitionId = entityDefinitionId,HasIndex = true,IsUnique = false,Name = "DeletedTime",PropertyTypeCode = "DateTime?",IsConstant = true },
        };
        await _entityPropertyDefinitionDal.AddRangeAsync(list);
    }
}
