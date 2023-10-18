﻿using IdentityServer.Entities.Db;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.DataAccess.Contracts
{
    public interface IIdentityUserDal : IEntityRepositoryBase<IdentityUser>
    {
    }
}
