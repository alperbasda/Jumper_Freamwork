using AutoMapper;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.DeleteByUserId;
using IdentityServer.Application.Features.UserRefreshTokens.Rules;
using IdentityServer.Application.Services.Repositories;
using MediatR;

namespace IdentityServer.Application.Features.UserRefreshTokens.Handlers.Commands.DeleteByUserId;

public class DeleteByUserIdRefreshTokenCommandHandler : IRequestHandler<DeleteByUserIdRefreshTokenCommand, DeleteByUserIdRefreshTokenResponse>
{
    private readonly IUserRefreshTokenDal _userRefreshTokenDal;
    private readonly UserRefreshTokenBusinessRules _userRefreshTokenBusinessRules;
    private readonly IMapper _mapper;

    public DeleteByUserIdRefreshTokenCommandHandler(IMapper mapper, IUserRefreshTokenDal userRefreshTokenDal, UserRefreshTokenBusinessRules userRefreshTokenBusinessRules)
    {
        _mapper = mapper;
        _userRefreshTokenDal = userRefreshTokenDal;
        _userRefreshTokenBusinessRules = userRefreshTokenBusinessRules;
    }

    public async Task<DeleteByUserIdRefreshTokenResponse> Handle(DeleteByUserIdRefreshTokenCommand request, CancellationToken cancellationToken)
    {

        var data = await _userRefreshTokenDal.GetAsync(w => w.UserId == request.UserId);

        _userRefreshTokenBusinessRules.ThrowExceptionIfDataNull(data);

        //İş Kurallarınızı Burada Çağırabilirsiniz.

        await _userRefreshTokenDal.DeleteAsync(data!,permanent:true);

        return _mapper.Map<DeleteByUserIdRefreshTokenResponse>(data);
    }
}
