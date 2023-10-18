using Core.ApiHelpers.JwtHelper.Models;
using Jumper.Application.Base;

namespace Jumper.Application.Features.ProjectEntityDependencies.Rules;

public class ProjectEntityActionDependencyBusinessRules : BaseBusinessRules
{
    public ProjectEntityActionDependencyBusinessRules(TokenParameters tokenParameters) : base(tokenParameters)
    {

    }
}
