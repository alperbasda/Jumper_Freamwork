
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.UserPasswords.Commands.DeleteById;
using IdentityServer.Application.Features.UserPasswords.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.UserPasswords.Handlers.Commands.DeleteById;

public class DeleteByIdUserPasswordCommandHandler : IRequestHandler<DeleteByIdUserPasswordCommand, DeleteByIdUserPasswordResponse>
{
    private readonly IUserPasswordDal _userPasswordDal;
    private readonly UserPasswordBusinessRules _userPasswordBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdUserPasswordCommandHandler(IMapper mapper, IUserPasswordDal userPasswordDal, UserPasswordBusinessRules userPasswordBusinessRules)
    {
        _mapper = mapper;
        _userPasswordDal = userPasswordDal;
        _userPasswordBusinessRules = userPasswordBusinessRules;
    }

    public async Task<DeleteByIdUserPasswordResponse> Handle(DeleteByIdUserPasswordCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _userPasswordDal.GetAsync(w => w.Id == request.Id);
            
        _userPasswordBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _userPasswordDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdUserPasswordResponse>(data);
    }
}


