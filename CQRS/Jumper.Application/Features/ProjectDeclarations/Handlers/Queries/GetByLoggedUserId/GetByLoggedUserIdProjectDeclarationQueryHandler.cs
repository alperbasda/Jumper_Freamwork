using AutoMapper;
using Core.ApiHelpers.JwtHelper.Models;
using Core.Persistence.Models.Responses;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByLoggedUserId;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetByLoggedUserId;

public class GetByLoggedUserIdProjectDeclarationQueryHandler : IRequestHandler<GetByLoggedUserIdProjectDeclarationQuery, ListModel<GetByLoggedUserIdProjectDeclarationResponse>>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    TokenParameters _tokenParameters;
    IMapper _mapper;

    public GetByLoggedUserIdProjectDeclarationQueryHandler(IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IProjectDeclarationDal projectDeclarationDal, TokenParameters tokenParameters)
    {
        _mapper = mapper;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _projectDeclarationDal = projectDeclarationDal;
        _tokenParameters = tokenParameters;
    }

    public async Task<ListModel<GetByLoggedUserIdProjectDeclarationResponse>> Handle(GetByLoggedUserIdProjectDeclarationQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectDeclarationDal.GetListAsync(w => _tokenParameters.IsSuperUser || w.UserId == _tokenParameters.UserId, size: int.MaxValue);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(data);

        return _mapper.Map<ListModel<GetByLoggedUserIdProjectDeclarationResponse>>(data);
    }
}
