using AutoMapper;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.EntityDefinitions.Queries.GetListDynamic;
using Jumper.Application.Features.EntityDefinitions.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.EntityDefinitions.Handlers.Queries.GetListDynamic
{
    public class GetListDynamicEntityDefinitionQueryHandler : IRequestHandler<GetListDynamicEntityDefinitionQuery, ListModel<GetListDynamicEntityDefinitionQueryResponse>>
    {
        IEntityDefinitionDal _entityDefinitionDal;
        EntityDefinitionBusinessRules _entityDefinitionBusinessRules;
        IMapper _mapper;

        public GetListDynamicEntityDefinitionQueryHandler(IEntityDefinitionDal entityDefinitionDal, IMapper mapper, EntityDefinitionBusinessRules entityDefinitionBusinessRules)
        {
            _entityDefinitionDal = entityDefinitionDal;
            _mapper = mapper;
            _entityDefinitionBusinessRules = entityDefinitionBusinessRules;
        }

        public async Task<ListModel<GetListDynamicEntityDefinitionQueryResponse>> Handle(GetListDynamicEntityDefinitionQuery request, CancellationToken cancellationToken)
        {
            _entityDefinitionBusinessRules.AddLoggedUserIdInDynamicQuery(request.DynamicQuery);

            var pageData = await _entityDefinitionDal.GetListByDynamicAsync(request.DynamicQuery, index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

            var viewData = _mapper.Map<ListModel<GetListDynamicEntityDefinitionQueryResponse>>(pageData);
            _entityDefinitionBusinessRules.FillDynamicFilter(viewData, request.DynamicQuery, request.PageRequest);

            return viewData;
        }
    }
}
