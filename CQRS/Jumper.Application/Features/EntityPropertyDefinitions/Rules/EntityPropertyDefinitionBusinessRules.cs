using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;

namespace Jumper.Application.Features.EntityPropertyDefinitions.Rules;

public class EntityPropertyDefinitionBusinessRules : BaseBusinessRules
{
    private readonly IEntityPropertyDefinitionDal _entityPropertyDefinitionDal;
    private readonly IEntityDefinitionDal _entityDefinitionDal;

    public EntityPropertyDefinitionBusinessRules(TokenParameters tokenParameters, IEntityPropertyDefinitionDal entityPropertyDefinitionDal, IEntityDefinitionDal entityDefinitionDal) : base(tokenParameters)
    {
        _entityPropertyDefinitionDal = entityPropertyDefinitionDal;
        _entityDefinitionDal = entityDefinitionDal;
    }

    public async Task ThrowExceptionIfSameNamedDataExistsForCreate(string name, Guid entityDefinitionId)
    {
        if (await _entityPropertyDefinitionDal.AnyAsync(w => w.Name == name && w.EntityDefinitionId == entityDefinitionId))
        {
            throw new BusinessException("Aynı ada sahip veri daha önce eklenmiş");
        }
    }

    public async Task ThrowExceptionIfSameNamedDataExistsForUpdate(string name, Guid id, Guid entityDefinitionId)
    {
        if (await _entityPropertyDefinitionDal.AnyAsync(w => w.Name == name && w.Id != id && w.EntityDefinitionId == entityDefinitionId))
        {
            throw new BusinessException("Aynı ada sahip veri daha önce eklenmiş");
        }
    }

    public async Task ThrowExceptionIfEntityDeclarationOwnerIsNotLoggedUser(Guid entityDefinitionId)
    {
        if (TokenParameters.IsSuperUser)
            return;
        if (await _entityDefinitionDal.AnyAsync(w=> w.UserId == TokenParameters.UserId && w.Id == entityDefinitionId))
        {
            throw new BusinessException("Bu veri üzerinde sadece verinin sahibi işlem yapabilir.");
        }
    }

    public void ThrowExceptionIfEntityDeclarationOwnerIsNotLoggedUser(EntityDefinition entityDefinition)
    {
        if (TokenParameters.IsSuperUser)
            return;
        if (entityDefinition.UserId != TokenParameters.UserId)
        {
            throw new BusinessException("Bu veri üzerinde sadece verinin sahibi işlem yapabilir.");
        }
    }

}
