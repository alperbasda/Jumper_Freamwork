using EntityBase.Poco.Responses;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Poco.Client;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;
using Tools.Hashing;

namespace IdentityServer.Business.Concrete
{
    public class ClientManager : BaseService<Client, CreateClientRequest, UpdateClientRequest, ClientResponse>, IClientService
    {
        public ClientManager(IClientDal repository, IQueryableRepositoryBase<Client> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
        }

        public async override Task<Response<ClientResponse>> Update(UpdateClientRequest request)
        {
            var client =await base.GetAsync(request.Id);
            if (!client.IsSuccessful)
                return client;

            request.ClientSecret = client.Data.ClientSecret;
            request.ClientSecretSalt = client.Data.ClientSecretSalt;
            return await base.Update(request);
        }

        public override async Task<Response<ClientResponse>> Create(CreateClientRequest request)
        {
            byte[] secretHash, secretSalt;
            HashingHelper.CreatePasswordHash(request.ClientSecretStr, out secretHash, out secretSalt);
            request.ClientSecretSalt = secretSalt;
            request.ClientSecret = secretHash;
            var res = await base.Create(request);
            if (res.IsSuccessful)
            {
                res.Data.ClientSecretStr = request.ClientSecretStr;
            }
            return res;
        }
    }
}
