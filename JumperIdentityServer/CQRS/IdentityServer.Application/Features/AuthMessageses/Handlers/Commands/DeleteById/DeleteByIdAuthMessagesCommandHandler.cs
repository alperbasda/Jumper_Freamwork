
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.AuthMessageses.Commands.DeleteById;
using IdentityServer.Application.Features.AuthMessageses.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.AuthMessageses.Handlers.Commands.DeleteById;

public class DeleteByIdAuthMessagesCommandHandler : IRequestHandler<DeleteByIdAuthMessagesCommand, DeleteByIdAuthMessagesResponse>
{
    private readonly IAuthMessagesDal _authMessagesDal;
    private readonly AuthMessagesBusinessRules _authMessagesBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdAuthMessagesCommandHandler(IMapper mapper, IAuthMessagesDal authMessagesDal, AuthMessagesBusinessRules authMessagesBusinessRules)
    {
        _mapper = mapper;
        _authMessagesDal = authMessagesDal;
        _authMessagesBusinessRules = authMessagesBusinessRules;
    }

    public async Task<DeleteByIdAuthMessagesResponse> Handle(DeleteByIdAuthMessagesCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _authMessagesDal.GetAsync(w => w.Id == request.Id);
            
        _authMessagesBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _authMessagesDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdAuthMessagesResponse>(data);
    }
}



