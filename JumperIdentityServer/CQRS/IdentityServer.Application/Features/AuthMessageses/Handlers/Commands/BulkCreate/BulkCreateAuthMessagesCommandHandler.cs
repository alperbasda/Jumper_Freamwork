
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.AuthMessageses.Commands.BulkCreate;
using IdentityServer.Application.Features.AuthMessageses.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;

using MediatR;
namespace IdentityServer.Application.Features.AuthMessageses.Handlers.Commands.BulkCreate;

public class BulkCreateAuthMessagesCommandHandler : IRequestHandler<BulkCreateAuthMessagesWrapperCommand, List<BulkCreateAuthMessagesResponse>>
{
    private readonly IAuthMessagesDal _authMessagesDal;
    private readonly AuthMessagesBusinessRules _authMessagesBusinessRules;
    private readonly IMapper _mapper;

    public BulkCreateAuthMessagesCommandHandler(IMapper mapper, IAuthMessagesDal authMessagesDal, AuthMessagesBusinessRules authMessagesBusinessRules)
    {
        _mapper = mapper;
        _authMessagesDal = authMessagesDal;
        _authMessagesBusinessRules = authMessagesBusinessRules;
    }

    public async Task<List<BulkCreateAuthMessagesResponse>> Handle(BulkCreateAuthMessagesWrapperCommand request, CancellationToken cancellationToken)
    {
        var datas = _mapper.Map<List<AuthMessages>>(request);

        _authMessagesBusinessRules.SetId(datas);
        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _authMessagesDal.AddRangeAsync(datas);

        return _mapper.Map<List<BulkCreateAuthMessagesResponse>>(datas);
    }
}



