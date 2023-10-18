using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Jumper.Application.Base;
using Jumper.Application.Features.ProjectEntityActions.Commands.Create;
using Jumper.Application.Features.ProjectEntityActions.Queries.GetListByProjectEntityId;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Entities;
using Jumper.Domain.Enums;
using MassTransit.Internals.GraphValidation;

namespace Jumper.Application.Features.ProjectEntityActions.Rules;

public class ProjectEntityActionBusinessRules : BaseBusinessRules
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly IProjectEntityPropertyDal _projectEntityPropertyDal;
    private readonly IProjectEntityActionDal _projectEntityActionDal;
    public ProjectEntityActionBusinessRules(TokenParameters tokenParameters, IProjectEntityActionDal projectEntityActionDal, IProjectEntityDal projectEntityDal, IProjectEntityPropertyDal projectEntityPropertyDal) : base(tokenParameters)
    {
        _projectEntityActionDal = projectEntityActionDal;
        _projectEntityDal = projectEntityDal;
        _projectEntityPropertyDal = projectEntityPropertyDal;
    }

    public async Task ThrowExceptionIfProjectEntityUserNotLoggedUser(Guid projectEntityId)
    {
        if (TokenParameters.IsSuperUser || await _projectEntityDal.AnyAsync(e => e.Id == projectEntityId && e.UserId == TokenParameters.UserId))
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

    public void MapProjectEntityActionProperties(CreateProjectEntityActionCommand request, ProjectEntityAction projectEntityAction)
    {
        projectEntityAction.Properties = new List<ProjectEntityActionProperty>();

        if (request.ResponseProperties != null)
        {
            foreach (var item in request.ResponseProperties)
            {
                projectEntityAction.Properties.Add(
                    new ProjectEntityActionProperty
                    {
                        Id = Guid.NewGuid(),
                        ActionPropertyType = ActionPropertyType.Response,
                        CreatedTime = DateTime.Now,
                        ProjectEntityActionId = projectEntityAction.Id,
                        ProjectEntityPropertyId = item
                    }
                    );
            }
        }

        if (request.RequestProperties != null)
        {
            foreach (var item in request.RequestProperties)
            {
                projectEntityAction.Properties.Add(
                    new ProjectEntityActionProperty
                    {
                        Id = Guid.NewGuid(),
                        ActionPropertyType = ActionPropertyType.Request,
                        CreatedTime = DateTime.Now,
                        ProjectEntityActionId = projectEntityAction.Id,
                        ProjectEntityPropertyId = item
                    }
                );
            }
        }
    }

    public string FillEntityActionPropertyNamesStr(List<ProjectEntityProperty> propertyList, List<ProjectEntityActionProperty>? relatedProperties, ActionPropertyType type)
    {
        if (relatedProperties == null)
            return "";

        var ids = relatedProperties.Where(w => w.ActionPropertyType == type).Select(w => w.ProjectEntityPropertyId);
        return string.Join("<br/> ", propertyList.Where(w => ids.Contains(w.Id)).Select(w => w.Name).OrderBy(q=>q));

    }

    public async Task<List<ProjectEntityProperty>> GetProjectEntityProperties(Guid projectEntityId)
    {
        return (await _projectEntityPropertyDal.GetListAsync(w => w.ProjectEntityId == projectEntityId)).Items.ToList();
    }

}
