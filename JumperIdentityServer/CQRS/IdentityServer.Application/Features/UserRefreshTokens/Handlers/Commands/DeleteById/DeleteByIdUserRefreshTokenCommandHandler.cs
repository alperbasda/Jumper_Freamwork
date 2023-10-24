
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.DeleteById;
using IdentityServer.Application.Features.UserRefreshTokens.Rules;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using MediatR;
namespace IdentityServer.Application.Features.UserRefreshTokens.Handlers.Commands.DeleteById;

public class DeleteByIdUserRefreshTokenCommandHandler : IRequestHandler<DeleteByIdUserRefreshTokenCommand, DeleteByIdUserRefreshTokenResponse>
{
    private readonly IUserRefreshTokenDal _userRefreshTokenDal;
    private readonly UserRefreshTokenBusinessRules _userRefreshTokenBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByIdUserRefreshTokenCommandHandler(IMapper mapper, IUserRefreshTokenDal userRefreshTokenDal, UserRefreshTokenBusinessRules userRefreshTokenBusinessRules)
    {
        _mapper = mapper;
        _userRefreshTokenDal = userRefreshTokenDal;
        _userRefreshTokenBusinessRules = userRefreshTokenBusinessRules;
    }

    public async Task<DeleteByIdUserRefreshTokenResponse> Handle(DeleteByIdUserRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        
        var data = await _userRefreshTokenDal.GetAsync(w => w.Id == request.Id);
            
        _userRefreshTokenBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _userRefreshTokenDal.DeleteAsync(data!);

        return _mapper.Map<DeleteByIdUserRefreshTokenResponse>(data);
    }
}



