using AutoMapper;
using Jumper.Application.Features.ProjectEntityProperties.Queries.GetById;
using Jumper.Application.Features.ProjectEntityProperties.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Queries.GetById;

public class GetByIdProjectEntityPropertyQueryHandler : IRequestHandler<GetByIdProjectEntityPropertyQuery, GetByIdProjectEntityPropertyResponse>
{
    private readonly IProjectEntityPropertyDal _projectEntityPropertyDal;
    private readonly ProjectEntityPropertyBusinessRules _projectEntityPropertyBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdProjectEntityPropertyQueryHandler(IMapper mapper, ProjectEntityPropertyBusinessRules projectEntityPropertyBusinessRules, IProjectEntityPropertyDal projectEntityPropertyDal)
    {
        _mapper = mapper;
        _projectEntityPropertyBusinessRules = projectEntityPropertyBusinessRules;
        _projectEntityPropertyDal = projectEntityPropertyDal;
    }


    public async Task<GetByIdProjectEntityPropertyResponse> Handle(GetByIdProjectEntityPropertyQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityPropertyDal.GetAsync(w => w.Id == request.Id);
        await _projectEntityPropertyBusinessRules.ThrowExceptionIfDataNull(data);
        await _projectEntityPropertyBusinessRules.ThrowExceptionIfProjectDeclarationUserNotLoggedUser(data!.ProjectDeclarationRef, data.ProjectEntityId);

        return _mapper.Map<GetByIdProjectEntityPropertyResponse>(data);
    }
}
