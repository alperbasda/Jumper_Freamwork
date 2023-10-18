using AutoMapper;
using Jumper.Application.Features.ProjectEntities.Commands.Delete;
using Jumper.Application.Features.ProjectEntities.Rules;
using Jumper.Application.Services.Repositories;
using MediatR;

namespace Jumper.Application.Features.ProjectEntities.Handlers.Commands.Delete;

public class DeleteProjectEntityCommandHandler : IRequestHandler<DeleteProjectEntityCommand, DeleteProjectEntityResponse>
{
    private readonly IProjectEntityDal _projectEntityDal;
    private readonly ProjectEntityBusinessRules _projectEntityBusinessRules;
    private readonly IMapper _mapper;

    public DeleteProjectEntityCommandHandler(IMapper mapper, ProjectEntityBusinessRules projectEntityBusinessRules, IProjectEntityDal projectEntityDal)
    {
        _mapper = mapper;
        _projectEntityBusinessRules = projectEntityBusinessRules;
        _projectEntityDal = projectEntityDal;
    }

    public async Task<DeleteProjectEntityResponse> Handle(DeleteProjectEntityCommand request, CancellationToken cancellationToken)
    {
        var data = await _projectEntityDal.GetAsync(w => w.Id == request.Id); 
        
        await _projectEntityBusinessRules.ThrowExceptionIfDataNull(data);
        _projectEntityBusinessRules.ThrowExceptionIfDataOwnerNotLoggedUser(data!);
        _projectEntityBusinessRules.ThrowExceptionEntityIsConstant(data!);

        await _projectEntityDal.DeleteAsync(data!);

        return _mapper.Map<DeleteProjectEntityResponse>(data);

    }
}
