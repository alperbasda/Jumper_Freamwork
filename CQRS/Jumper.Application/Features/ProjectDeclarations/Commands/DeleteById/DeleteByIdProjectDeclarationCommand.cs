using Core.ApiHelpers.JwtHelper.Models;
using Core.Application.Pipelines.Caching;
using MediatR;


namespace Jumper.Application.Features.ProjectDeclarations.Commands.DeleteById;

public class DeleteByIdProjectDeclarationCommand : IRequest<DeleteByIdProjectDeclarationResponse> , ICacheRemoverRequest
{
    TokenParameters _tokenParameters;

    public DeleteByIdProjectDeclarationCommand(TokenParameters tokenParameters)
    {
        _tokenParameters = tokenParameters;
    }

    public Guid Id { get; set; }

    public string CacheKey => $"Projects_{_tokenParameters.UserId}";

    public bool BypassCache => false;

    public string? CacheGroupKey => "Projects";
}
