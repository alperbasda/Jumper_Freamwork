using Core.ApiHelpers.JwtHelper.Models;
using Jumper.Application.Base;

namespace Jumper.Application.Features.ArchitectureDefinitions.Rules;

public class ArchitectureDefinitionBusinessRules : BaseBusinessRules
{
    public ArchitectureDefinitionBusinessRules(TokenParameters tokenParameters) : base(tokenParameters)
    {
    }
}
