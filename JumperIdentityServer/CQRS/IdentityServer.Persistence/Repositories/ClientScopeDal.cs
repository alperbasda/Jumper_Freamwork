
//---------------------------------------------------------------------------------------
//      This code was generated by a Jumper tool. 
//      Runtime version : 1.0
//      Generation Time : 23.10.2023 11:28
//---------------------------------------------------------------------------------------

using Core.Persistence.Repositories;
using IdentityServer.Application.Services.Repositories;
using IdentityServer.Domain.Entities;
using IdentityServer.Persistence.Contexts;
namespace IdentityServer.Persistence.Repositories;

public class ClientScopeDal : EfRepositoryBase<ClientScope, Guid, IdentityServerDbContext>, IClientScopeDal
{
    public ClientScopeDal(IdentityServerDbContext context) : base(context)
    {
    }
}

