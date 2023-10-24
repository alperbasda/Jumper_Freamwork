
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.BulkCreate;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.Create;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.Update;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.BulkUpdate;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.DeleteById;
using IdentityServer.Application.Features.UserRefreshTokens.Queries.ListDynamic;
using IdentityServer.Application.Features.UserRefreshTokens.Queries.GetById;
using IdentityServer.Domain.Entities;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.DeleteByUserId;
using IdentityServer.Application.Features.UserRefreshTokens.Commands.DeleteByCode;

namespace IdentityServer.Application.Features.UserRefreshTokens.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
		CreateMap<BulkCreateUserRefreshTokenCommand,UserRefreshToken>();
		CreateMap<UserRefreshToken, BulkCreateUserRefreshTokenResponse>();
		CreateMap<CreateUserRefreshTokenCommand,UserRefreshToken>();
		CreateMap<UserRefreshToken, CreateUserRefreshTokenResponse>();
		CreateMap<UpdateUserRefreshTokenCommand,UserRefreshToken>();
		CreateMap<UserRefreshToken, UpdateUserRefreshTokenResponse>();
		CreateMap<BulkUpdateUserRefreshTokenCommand,UserRefreshToken>();
		CreateMap<UserRefreshToken, BulkUpdateUserRefreshTokenResponse>();
		CreateMap<DeleteByIdUserRefreshTokenCommand,UserRefreshToken>();
		CreateMap<UserRefreshToken, DeleteByIdUserRefreshTokenResponse>();
		CreateMap<Paginate<UserRefreshToken>, ListModel<ListDynamicUserRefreshTokenResponse>>();
		CreateMap<UserRefreshToken, ListDynamicUserRefreshTokenResponse>();
		CreateMap<UserRefreshToken, GetByIdUserRefreshTokenResponse>();
        CreateMap<UserRefreshToken, DeleteByUserIdRefreshTokenResponse>();
        CreateMap<UserRefreshToken, DeleteByCodeUserRefreshTokenResponse>();
        
    }
}



