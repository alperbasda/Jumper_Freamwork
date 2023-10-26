using AutoMapper;
using Core.ApiHelpers.JwtHelper.Models;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetListDynamic;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetListDynamic
{
    public class GetListDynamicProjectDeclarationQueryHandler : IRequestHandler<GetListDynamicProjectDeclarationQuery, ListModel<GetListDynamicProjectDeclarationQueryResponse>>
    {
        IProjectDeclarationDal _projectDeclarationDal;
        IMapper _mapper;
        ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
        TokenParameters _tokenParameters;

        public GetListDynamicProjectDeclarationQueryHandler(IProjectDeclarationDal projectDeclarationDal, IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, TokenParameters tokenParameters)
        {
            _projectDeclarationDal = projectDeclarationDal;
            _mapper = mapper;
            _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
            _tokenParameters = tokenParameters;
        }

        public async Task<ListModel<GetListDynamicProjectDeclarationQueryResponse>> Handle(GetListDynamicProjectDeclarationQuery request, CancellationToken cancellationToken)
        {
            _projectDeclarationBusinessRules.AddLoggedUserIdInDynamicQuery(request.DynamicQuery);
            
            var pageData = await _projectDeclarationDal.GetListByDynamicAsync(request.DynamicQuery, w => (_tokenParameters.IsSuperUser || w.UserId == _tokenParameters.UserId), index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, cancellationToken: cancellationToken);

            var viewData = _mapper.Map<ListModel<GetListDynamicProjectDeclarationQueryResponse>>(pageData);
            _projectDeclarationBusinessRules.FillDynamicFilter(viewData, request.DynamicQuery, request.PageRequest);

            return viewData;
        }
    }
}
