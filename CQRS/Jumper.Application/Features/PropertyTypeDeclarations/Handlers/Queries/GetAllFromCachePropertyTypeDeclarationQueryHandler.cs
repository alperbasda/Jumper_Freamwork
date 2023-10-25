using AutoMapper;
using Jumper.Application.Features.PropertyInputTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Application.Features.PropertyTypeDeclarations.Queries.GetAllFromCache;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.PropertyTypeDeclarations.Handlers.Queries;

public class GetAllFromCachePropertyTypeDeclarationQueryHandler : IRequestHandler<GetAllFromCachePropertyTypeDeclarationQuery, List<GetAllFromCachePropertyTypeDeclarationResponse>>
{
    IPropertyTypeDeclarationDal _propertyTypeDeclarationDal;
    IMapper _mapper;

    public GetAllFromCachePropertyTypeDeclarationQueryHandler(IPropertyTypeDeclarationDal propertyTypeDeclarationDal, IMapper mapper)
    {
        _propertyTypeDeclarationDal = propertyTypeDeclarationDal;
        _mapper = mapper;
    }

    public async Task<List<GetAllFromCachePropertyTypeDeclarationResponse>> Handle(GetAllFromCachePropertyTypeDeclarationQuery request, CancellationToken cancellationToken)
    {
        var types = await _propertyTypeDeclarationDal.GetListAsync(size: int.MaxValue, index: 0, cancellationToken: cancellationToken);

        return _mapper.Map<List<GetAllFromCachePropertyTypeDeclarationResponse>>(types.Items);
    }
}
