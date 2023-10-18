using Core.ApiHelpers.JwtHelper.Models;
using Jumper.Application.Base;

namespace Jumper.Application.Features.ProjectEntityActionProperties.Rules;

public class ProjectEntityActionPropertyBusinessRules : BaseBusinessRules
{
    public ProjectEntityActionPropertyBusinessRules(TokenParameters tokenParameters) : base(tokenParameters)
    {
    }
}
