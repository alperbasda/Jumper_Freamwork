using Core.Application.Pipelines.Caching;
using MediatR;

namespace Jumper.Application.Features.PropertyTypeDeclarations.Queries.GetAllFromCache;

public class GetAllFromCachePropertyTypeDeclarationQuery : IRequest<List<GetAllFromCachePropertyTypeDeclarationResponse>>
{

}
