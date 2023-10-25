using AutoMapper;
using Jumper.Application.Features.PropertyInputTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.PropertyInputTypeDeclarations.Handlers.Queries;

public class GetAllFromCachePropertyInputTypeDeclarationQueryHandler : IRequestHandler<GetAllFromCachePropertyInputTypeDeclarationQuery, List<GetAllFromCachePropertyInputTypeDeclarationResponse>>
{
    IPropertyInputTypeDeclarationDal _propertyInputTypeDeclarationDal;
    IMapper _mapper;

    public GetAllFromCachePropertyInputTypeDeclarationQueryHandler(IPropertyInputTypeDeclarationDal propertyInputTypeDeclarationDal, IMapper mapper)
    {
        _propertyInputTypeDeclarationDal = propertyInputTypeDeclarationDal;
        _mapper = mapper;
    }

    public async Task<List<GetAllFromCachePropertyInputTypeDeclarationResponse>> Handle(GetAllFromCachePropertyInputTypeDeclarationQuery request, CancellationToken cancellationToken)
    {
        var types = await _propertyInputTypeDeclarationDal.GetListAsync(size: int.MaxValue, index: 0, cancellationToken: cancellationToken);

        return _mapper.Map<List<GetAllFromCachePropertyInputTypeDeclarationResponse>>(types.Items);
    }
}
