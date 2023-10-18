using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Services.Repositories;

namespace Jumper.Application.Features.ProjectEntityProperties.Rules;

public class ProjectEntityPropertyBusinessRules : BaseBusinessRules
{
    private readonly IProjectEntityDal _projectEntityDal;
    IProjectEntityPropertyDal _projectEntityPropertyDal;

    public ProjectEntityPropertyBusinessRules(TokenParameters tokenParameters, IProjectEntityDal projectEntityDal, IProjectEntityPropertyDal projectEntityPropertyDal) : base(tokenParameters)
    {
        _projectEntityDal = projectEntityDal;
        _projectEntityPropertyDal = projectEntityPropertyDal;
    }

    public async Task ThrowExceptionIfProjectEntityUserNotLoggedUser(Guid projectEntityId)
    {

        var result = await _projectEntityDal.AnyAsync(e => e.Id == projectEntityId && e.UserId == TokenParameters.UserId);

        if (TokenParameters.IsSuperUser || result)
        {
            return;
        }

        throw new BusinessException("Sadece yetkili olduğunuz projeler için işlem yapabilirsiniz.");
    }

    public async Task ThrowExceptionIfSameNamedDataExists(string name, Guid projectEntityId)
    {
        if (await _projectEntityPropertyDal.AnyAsync(w => w.Name == name && w.ProjectEntityId == projectEntityId))
        {
            throw new BusinessException("Aynı ada sahip veri daha önce eklenmiş");
        }
    }

}
