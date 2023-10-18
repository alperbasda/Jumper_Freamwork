using AutoMapper;
using Jumper.Application.Features.ProjectDeclaration.Rules;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetTopOneWaitingGenerate;
using Jumper.Application.Services.Repositories;
using Jumper.Domain.Enums;
using MediatR;


namespace Jumper.Application.Features.ProjectDeclarations.Handlers.Queries.GetTopOneWaitingGenerate;

public class GetTopOneWaitingGenerateProjectDeclarationQueryHandler : IRequestHandler<GetTopOneWaitingGenerateProjectDeclarationQuery, GetTopOneWaitingGenerateProjectDeclarationResponse>
{
    private readonly IProjectDeclarationDal _projectDeclarationDal;
    private readonly ProjectDeclarationBusinessRules _projectDeclarationBusinessRules;
    private readonly IMapper _mapper;

    public GetTopOneWaitingGenerateProjectDeclarationQueryHandler(IProjectDeclarationDal projectDeclarationDal, ProjectDeclarationBusinessRules projectDeclarationBusinessRules, IMapper mapper)
    {
        _projectDeclarationDal = projectDeclarationDal;
        _projectDeclarationBusinessRules = projectDeclarationBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetTopOneWaitingGenerateProjectDeclarationResponse> Handle(GetTopOneWaitingGenerateProjectDeclarationQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectDeclarationDal.GetAsync(w => w.ProjectStatus == ProjectStatus.WaitingGenerate);

        await _projectDeclarationBusinessRules.ThrowExceptionIfDataNull(data);

        return _mapper.Map<GetTopOneWaitingGenerateProjectDeclarationResponse>(data);
    }
}
