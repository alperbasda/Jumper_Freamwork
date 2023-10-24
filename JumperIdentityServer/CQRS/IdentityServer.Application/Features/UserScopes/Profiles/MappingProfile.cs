



//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using IdentityServer.Application.Features.UserScopes.Commands.BulkCreate;
using IdentityServer.Application.Features.UserScopes.Commands.Create;
using IdentityServer.Application.Features.UserScopes.Commands.Update;
using IdentityServer.Application.Features.UserScopes.Commands.BulkUpdate;
using IdentityServer.Application.Features.UserScopes.Commands.DeleteById;
using IdentityServer.Application.Features.UserScopes.Queries.ListDynamic;
using IdentityServer.Application.Features.UserScopes.Queries.GetById;
using IdentityServer.Domain.Entities;

namespace IdentityServer.Application.Features.UserScopes.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
		CreateMap<BulkCreateUserScopeCommand,UserScope>();
		CreateMap<UserScope, BulkCreateUserScopeResponse>();
		CreateMap<CreateUserScopeCommand,UserScope>();
		CreateMap<UserScope, CreateUserScopeResponse>();
		CreateMap<UpdateUserScopeCommand,UserScope>();
		CreateMap<UserScope, UpdateUserScopeResponse>();
		CreateMap<BulkUpdateUserScopeCommand,UserScope>();
		CreateMap<UserScope, BulkUpdateUserScopeResponse>();
		CreateMap<DeleteByIdUserScopeCommand,UserScope>();
		CreateMap<UserScope, DeleteByIdUserScopeResponse>();
		CreateMap<Paginate<UserScope>, ListModel<ListDynamicUserScopeResponse>>();
		CreateMap<UserScope, ListDynamicUserScopeResponse>();
		CreateMap<UserScope, GetByIdUserScopeResponse>();
    }
}




