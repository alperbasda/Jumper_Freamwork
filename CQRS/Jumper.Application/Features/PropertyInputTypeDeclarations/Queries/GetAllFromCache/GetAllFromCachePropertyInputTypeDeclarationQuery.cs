using Core.Application.Pipelines.Caching;
using MediatR;

namespace Jumper.Application.Features.PropertyInputTypeDeclarations.Queries.GetAllFromCache;

public class GetAllFromCachePropertyInputTypeDeclarationQuery : IRequest<List<GetAllFromCachePropertyInputTypeDeclarationResponse>>
{

}
