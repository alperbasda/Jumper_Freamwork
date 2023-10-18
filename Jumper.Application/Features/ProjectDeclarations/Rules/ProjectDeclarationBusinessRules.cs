using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Services.Repositories;
using System.Linq.Expressions;

namespace Jumper.Application.Features.ProjectDeclaration.Rules;

public class ProjectDeclarationBusinessRules : BaseBusinessRules
{
    IProjectDeclarationDal _projectDeclarationDal;

    public ProjectDeclarationBusinessRules(IProjectDeclarationDal projectDeclarationDal, TokenParameters tokenParameters) : base(tokenParameters)
    {
        _projectDeclarationDal = projectDeclarationDal;
    }

    public async Task ThrowExceptionIfSamaNameProjectExists(string name)
    {
        if (await _projectDeclarationDal.AnyAsync(w => w.Name == name && w.UserId == TokenParameters.UserId))
        {
            throw new BusinessException("Aynı isimde proje daha önce kayıt edilmiş.");
        }
    }

    public Expression<Func<Domain.MongoEntities.ProjectDeclaration, bool>>? GetUserIdExpressionIfUserNotSuperUser()
    {
        return TokenParameters.IsSuperUser ? null : w => w.UserId == TokenParameters.UserId;
    }
}
