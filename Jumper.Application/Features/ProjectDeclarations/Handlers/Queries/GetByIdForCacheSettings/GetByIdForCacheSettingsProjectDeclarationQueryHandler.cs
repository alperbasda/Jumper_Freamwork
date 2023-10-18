
using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForCacheSettings;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetByIdForCacheSettings;

public class GetByIdForCacheSettingsProjectDeclarationQueryHandler : IRequestHandler<GetByIdForCacheSettingsProjectDeclarationQuery, GetByIdForCacheSettingsProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    IMapper _mapper;

    public GetByIdForCacheSettingsProjectDeclarationQueryHandler(IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IProjectDeclarationDal projectDeclarationDal)
    {
        _mapper = mapper;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _projectDeclarationDal = projectDeclarationDal;
    }

    public async Task<GetByIdForCacheSettingsProjectDeclarationResponse> Handle(GetByIdForCacheSettingsProjectDeclarationQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(project);

        _projectDeclarationBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(project!);

        return _mapper.Map<GetByIdForCacheSettingsProjectDeclarationResponse>(project);
    }
}
