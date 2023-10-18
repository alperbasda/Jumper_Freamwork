﻿using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Commands.UpdateRelationalDatabaseSettings;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Commands.UpdateNoSqlDatabaseSettings;

public class UpdateNoSqlDatabaseSettingsProjectDeclarationCommandHandler : IRequestHandler<UpdateRelationalDatabaseSettingsProjectDeclarationCommand, UpdateRelationalDatabaseSettingsProjectDeclarationResponse>
{
    IProjectDeclarationDal _projectDeclarationDal;
    ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    IMapper _mapper;

    public UpdateNoSqlDatabaseSettingsProjectDeclarationCommandHandler(IMapper mapper, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IProjectDeclarationDal projectDeclarationDal)
    {
        _mapper = mapper;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _projectDeclarationDal = projectDeclarationDal;
    }

    public async Task<UpdateRelationalDatabaseSettingsProjectDeclarationResponse> Handle(UpdateRelationalDatabaseSettingsProjectDeclarationCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectDeclarationDal.GetAsync(w => w.Id == request.Id, cancellationToken: cancellationToken);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(project);

        _projectDeclarationBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(project!);

        _mapper.Map(request, project);

        await _projectDeclarationDal.UpdateAsync(project!);

        return _mapper.Map<UpdateRelationalDatabaseSettingsProjectDeclarationResponse>(project);
    }
}
