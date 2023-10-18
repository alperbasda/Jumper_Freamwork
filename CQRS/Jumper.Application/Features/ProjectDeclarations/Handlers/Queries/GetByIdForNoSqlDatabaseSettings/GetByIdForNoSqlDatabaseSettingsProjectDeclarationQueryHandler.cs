using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetByIdForNoSqlDatabaseSettings;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetByIdForNoSqlDatabaseSettings;

public class GetByIdForNoSqlDatabaseSettingsProjectDeclarationQueryHandler : IRequestHandler<GetByIdForNoSqlDatabaseSettingsProjectDeclarationQuery, GetByIdForNoSqlDatabaseSettingsProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    IMapper _mapper;

    public GetByIdForNoSqlDatabaseSettingsProjectDeclarationQueryHandler(IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IProjectDeclarationDal projectDeclarationDal)
    {
        _mapper = mapper;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _projectDeclarationDal = projectDeclarationDal;
    }
    public async Task<GetByIdForNoSqlDatabaseSettingsProjectDeclarationResponse> Handle(GetByIdForNoSqlDatabaseSettingsProjectDeclarationQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(project);

        _projectDeclarationBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(project!);

        return _mapper.Map<GetByIdForNoSqlDatabaseSettingsProjectDeclarationResponse>(project);
    }
}
