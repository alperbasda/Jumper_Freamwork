using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
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

    public void FillDependencyEntityNames(GetWithAllDetailByIdProjectDeclarationResponse data)
    {
        foreach (var item in data.Relations)
        {
            item.DependedName = data.Entities.FirstOrDefault(w => w.Id == item.DependedId)?.Name ?? "";
            item.DependsOnName = data.Entities.FirstOrDefault(w => w.Id == item.DependsOnId)?.Name ?? "";
        }
    }

    public void FillEntityActionPropertyNames(GetWithAllDetailByIdProjectDeclarationResponse data)
    {
        foreach (var item in data.Entities.SelectMany(w=>w.Actions.SelectMany(w=>w.Properties)))
        {
            item.PropertyName = data.Entities.FirstOrDefault(w=>w.Properties.Any(q=>q.Id == item.ProjectEntityPropertyId))?.Properties.First(w => w.Id == item.ProjectEntityPropertyId)?.Name ?? "";
        }
    }


    public Expression<Func<Domain.MongoEntities.ProjectDeclaration, bool>>? GetUserIdExpressionIfUserNotSuperUser()
    {
        return TokenParameters.IsSuperUser ? null : w => w.UserId == TokenParameters.UserId;
    }
}
