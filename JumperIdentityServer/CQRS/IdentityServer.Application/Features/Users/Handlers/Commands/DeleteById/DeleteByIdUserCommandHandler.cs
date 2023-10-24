
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.Users.Commands.DeleteById;
using IdentityServer.Application.Features.Users.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.Users.Handlers.Commands.DeleteById;

public class DeleteByIdUserCommandHandler : IRequestHandler<DeleteByIdUserCommand, DeleteByIdUserResponse>
{
    private readonly IUserDal _userDal;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdUserCommandHandler(IMapper mapper, IUserDal userDal, UserBusinessRules userBusinessRules)
    {
        _mapper = mapper;
        _userDal = userDal;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<DeleteByIdUserResponse> Handle(DeleteByIdUserCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _userDal.GetAsync(w => w.Id == request.Id);
            
        _userBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _userDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdUserResponse>(data);
    }
}



