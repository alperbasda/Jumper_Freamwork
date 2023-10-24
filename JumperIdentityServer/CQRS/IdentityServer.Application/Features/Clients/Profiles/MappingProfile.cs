
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using AutoMapper;
using Core.Persistence.Models.Responses;
using Core.Persistence.Paging;
using IdentityServer.Application.Features.Clients.Commands.BulkCreate;
using IdentityServer.Application.Features.Clients.Commands.Create;
using IdentityServer.Application.Features.Clients.Commands.Update;
using IdentityServer.Application.Features.Clients.Commands.BulkUpdate;
using IdentityServer.Application.Features.Clients.Commands.DeleteById;
using IdentityServer.Application.Features.Clients.Queries.ListDynamic;
using IdentityServer.Application.Features.Clients.Queries.GetById;
using IdentityServer.Domain.Entities;

namespace IdentityServer.Application.Features.Clients.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
		CreateMap<BulkCreateClientCommand,Client>();
		CreateMap<Client, BulkCreateClientResponse>();
		CreateMap<CreateClientCommand,Client>();
		CreateMap<Client, CreateClientResponse>();
		CreateMap<UpdateClientCommand,Client>();
		CreateMap<Client, UpdateClientResponse>();
		CreateMap<BulkUpdateClientCommand,Client>();
		CreateMap<Client, BulkUpdateClientResponse>();
		CreateMap<DeleteByIdClientCommand,Client>();
		CreateMap<Client, DeleteByIdClientResponse>();
		CreateMap<Paginate<Client>, ListModel<ListDynamicClientResponse>>();
		CreateMap<Client, ListDynamicClientResponse>();
		CreateMap<Client, GetByIdClientResponse>();
    }
}




