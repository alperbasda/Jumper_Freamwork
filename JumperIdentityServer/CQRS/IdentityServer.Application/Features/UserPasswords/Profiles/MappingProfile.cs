
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using IdentityServer.Application.Features.UserPasswords.Commands.BulkCreate;
using IdentityServer.Application.Features.UserPasswords.Commands.Create;
using IdentityServer.Application.Features.UserPasswords.Commands.Update;
using IdentityServer.Application.Features.UserPasswords.Commands.BulkUpdate;
using IdentityServer.Application.Features.UserPasswords.Commands.DeleteById;
using IdentityServer.Application.Features.UserPasswords.Queries.ListDynamic;
using IdentityServer.Application.Features.UserPasswords.Queries.GetById;
using IdentityServer.Domain.Entities;
using IdentityServer.Application.Features.UserPasswords.Queries.GetByUserId;

namespace IdentityServer.Application.Features.UserPasswords.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
		CreateMap<BulkCreateUserPasswordCommand,UserPassword>();
		CreateMap<UserPassword, BulkCreateUserPasswordResponse>();
		CreateMap<CreateUserPasswordCommand,UserPassword>();
		CreateMap<UserPassword, CreateUserPasswordResponse>();
		CreateMap<UpdateUserPasswordCommand,UserPassword>();
		CreateMap<UserPassword, UpdateUserPasswordResponse>();
		CreateMap<BulkUpdateUserPasswordCommand,UserPassword>();
		CreateMap<UserPassword, BulkUpdateUserPasswordResponse>();
		CreateMap<DeleteByIdUserPasswordCommand,UserPassword>();
		CreateMap<UserPassword, DeleteByIdUserPasswordResponse>();
		CreateMap<Paginate<UserPassword>, ListModel<ListDynamicUserPasswordResponse>>();
		CreateMap<UserPassword, ListDynamicUserPasswordResponse>();
		CreateMap<UserPassword, GetByIdUserPasswordResponse>();
        CreateMap<UserPassword, GetByUserIdUserPasswordResponse>();
        
    }
}




