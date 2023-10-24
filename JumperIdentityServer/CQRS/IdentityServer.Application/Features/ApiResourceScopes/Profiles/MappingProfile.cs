
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using IdentityServer.Application.Features.ApiResourceScopes.Commands.BulkCreate;
using IdentityServer.Application.Features.ApiResourceScopes.Commands.Create;
using IdentityServer.Application.Features.ApiResourceScopes.Commands.Update;
using IdentityServer.Application.Features.ApiResourceScopes.Commands.BulkUpdate;
using IdentityServer.Application.Features.ApiResourceScopes.Commands.DeleteById;
using IdentityServer.Application.Features.ApiResourceScopes.Queries.ListDynamic;
using IdentityServer.Application.Features.ApiResourceScopes.Queries.GetById;
using IdentityServer.Domain.Entities;

namespace IdentityServer.Application.Features.ApiResourceScopes.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
		CreateMap<BulkCreateApiResourceScopeCommand,ApiResourceScope>();
		CreateMap<ApiResourceScope, BulkCreateApiResourceScopeResponse>();
		CreateMap<CreateApiResourceScopeCommand,ApiResourceScope>();
		CreateMap<ApiResourceScope, CreateApiResourceScopeResponse>();
		CreateMap<UpdateApiResourceScopeCommand,ApiResourceScope>();
		CreateMap<ApiResourceScope, UpdateApiResourceScopeResponse>();
		CreateMap<BulkUpdateApiResourceScopeCommand,ApiResourceScope>();
		CreateMap<ApiResourceScope, BulkUpdateApiResourceScopeResponse>();
		CreateMap<DeleteByIdApiResourceScopeCommand,ApiResourceScope>();
		CreateMap<ApiResourceScope, DeleteByIdApiResourceScopeResponse>();
		CreateMap<Paginate<ApiResourceScope>, ListModel<ListDynamicApiResourceScopeResponse>>();
		CreateMap<ApiResourceScope, ListDynamicApiResourceScopeResponse>();
		CreateMap<ApiResourceScope, GetByIdApiResourceScopeResponse>();
    }
}




