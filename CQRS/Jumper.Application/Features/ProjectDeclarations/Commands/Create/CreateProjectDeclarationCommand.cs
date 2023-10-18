using Core.ApiHelpers.JwtHelper.Models;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Commands.Create
{
    public class CreateProjectDeclarationCommandWithOutCache
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool UseDatabase { get; set; }

        public bool UseCache { get; set; }

        public bool UseRabbitMq { get; set; }

        public bool UseSerilog { get; set; }

        public bool CreateApi { get; set; }
        public bool CreateUI { get; set; }

    }
    public class CreateProjectDeclarationCommand : CreateProjectDeclarationCommandWithOutCache, IRequest<CreateProjectDeclarationResponse>, ICacheRemoverRequest
    {
        TokenParameters _tokenParameters;

        public CreateProjectDeclarationCommand(TokenParameters tokenParameters)
        {
            _tokenParameters = tokenParameters;
        }



        public string CacheKey => $"Projects_{_tokenParameters.UserId}";

        public bool BypassCache => false;

        public string? CacheGroupKey => "Projects";
    }
}
