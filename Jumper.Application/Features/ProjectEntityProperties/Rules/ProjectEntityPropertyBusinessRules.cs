using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Services.Repositories;

namespace Jumper.Application.Features.ProjectEntityProperties.Rules;

public class ProjectEntityPropertyBusinessRules : BaseBusinessRules
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly IProjectDeclarationDal _projectDeclarationDal;

    public ProjectEntityPropertyBusinessRules(TokenParameters tokenParameters, IProjectDeclarationDal projectDeclarationDal, IProjectEntityDal projectEntityDal) : base(tokenParameters)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _projectEntityDal = projectEntityDal;
    }

    public async Task ThrowExceptionIfProjectDeclarationUserNotLoggedUser(Guid projectDeclarationId, Guid projectEntityId)
    {

        var results = await Task.WhenAll
            (
                Task.Run(() => _projectDeclarationDal.AnyAsync(e => e.Id == projectDeclarationId && e.UserId == TokenParameters.UserId)),
                Task.Run(() => _projectEntityDal.AnyAsync(e =>  e.ProjectDeclarationId == projectDeclarationId && e.Id == projectEntityId))
            );

        if (TokenParameters.IsSuperUser || results.All(w => w == true))
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
    }

    public async Task ThrowExceptionIfSamaNameProjectEntityPropertyExists(Guid projectEntityId, string name)
    {
        if (await _projectEntityPropertyDal.AnyAsync(w => w.Name == name && w.ProjectEntityId == projectEntityId))
        {
            throw new BusinessException("Aynı isimde özellik daha önce kayıt edilmiş.");
        }
    }


}
