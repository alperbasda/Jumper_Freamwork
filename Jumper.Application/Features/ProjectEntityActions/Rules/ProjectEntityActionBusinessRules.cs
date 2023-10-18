using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Services.Repositories;

namespace Jumper.Application.Features.ProjectEntityActions.Rules;

public class ProjectEntityActionBusinessRules : BaseBusinessRules
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly IProjectDeclarationDal _projectDeclarationDal;
    private readonly IProjectEntityActionDal _projectEntityActionDal;
    public ProjectEntityActionBusinessRules(TokenParameters tokenParameters, IProjectEntityActionDal projectEntityActionDal, IProjectEntityDal projectEntityDal, IProjectDeclarationDal projectDeclarationDal) : base(tokenParameters)
    {
        _projectEntityActionDal = projectEntityActionDal;
        _projectEntityDal = projectEntityDal;
        _projectDeclarationDal = projectDeclarationDal;
    }

    public async Task ThrowExceptionIfProjectDeclarationUserNotLoggedUser(Guid projectDeclarationId, Guid projectEntityId)
    {

        var results = await Task.WhenAll
            (
                Task.Run(() => _projectDeclarationDal.AnyAsync(e => e.Id == projectDeclarationId && e.UserId == TokenParameters.UserId)),
                Task.Run(() => _projectEntityDal.AnyAsync(e => e.Id == projectEntityId && e.ProjectDeclarationId == projectDeclarationId))
            );

        if (TokenParameters.IsSuperUser || results.All(w => w == true))
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
    }

    public async Task ThrowExceptionIfProjectDeclarationUserNotLoggedUser(Guid projectDeclarationId)
    {
        if (TokenParameters.IsSuperUser || await _projectDeclarationDal.AnyAsync(e => e.Id == projectDeclarationId && e.UserId == TokenParameters.UserId))
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
    }

    public async Task ThrowExceptionIfSamaNameProjectEntityActionExists(string name)
    {
        if (await _projectEntityActionDal.AnyAsync(w => w.Name == name))
        {
            throw new BusinessException("Aynı isimde aksiyon daha önce kayıt edilmiş.");
        }
    }
,
}
