
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using MediatR;

namespace IdentityServer.Application.Features.UserRefreshTokens.Queries.GetById;

public class GetByIdUserRefreshTokenQuery : IRequest<GetByIdUserRefreshTokenResponse>  
{
    
	public Guid Id { get; set; }
    
}



