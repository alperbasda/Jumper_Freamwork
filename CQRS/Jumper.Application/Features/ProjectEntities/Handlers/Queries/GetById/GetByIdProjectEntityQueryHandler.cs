using AutoMapper;
using Jumper.Application.Features.ProjectEntities.Queries.GetById;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Queries.GetById;

public class GetByIdProjectEntityQueryHandler : IRequestHandler<GetByIdProjectEntityQuery, GetByIdProjectEntityResponse>
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly ProjectEntityBusinessRules _projectEntityBusinessRules;
    private readonly IMapper _mapper;

    public GetByIdProjectEntityQueryHandler(IMapper mapper, ProjectEntityBusinessRules projectEntityBusinessRules, IProjectEntityDal projectEntityDal)
    {
        _mapper = mapper;
        _projectEntityBusinessRules = projectEntityBusinessRules;
        _projectEntityDal = projectEntityDal;
    }


    public async Task<GetByIdProjectEntityResponse> Handle(GetByIdProjectEntityQuery request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityDal.GetAsync(w => w.Id == request.Id);

        await _projectEntityBusinessRules.ThrowExceptionIfDataNull(data);
        _projectEntityBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(data!);

        return _mapper.Map<GetByIdProjectEntityResponse>(data);
    }
}
