using AutoMapperAdapter;
using EntityBase.Enum;
using IdentityServer.DataAccess.Contexts;
using IdentityServer.Entities.Poco.ApiResource;
using IdentityServer.Entities.Poco.Client;
using IdentityServer.Entities.Poco.ClientApiResource;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Business.Constants
{
    public class AuthConfig
    {
        public static Guid DefaultUserRoleId = Guid.Parse("35215d8e-1c9b-49f4-8dce-f257185cf989");

        #region Scopes

        private static IEnumerable<ApiResourceScopeResponse> _apiScopes;

        public static IEnumerable<ApiResourceScopeResponse> ApiScopes
        {
            get
            {
                return _apiScopes;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Resources

        private static IEnumerable<ApiResourceResponse> _apiResources;

        public static IEnumerable<ApiResourceResponse> ApiResources
        {
            get
            {
                return _apiResources;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Clients

        private static IEnumerable<ClientResponse> _clients;

        public static IEnumerable<ClientResponse> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ClientResources

        private static IEnumerable<ClientApiResourceResponse> _clientResources;

        public static IEnumerable<ClientApiResourceResponse> ClientResources
        {
            get
            {
                return _clientResources;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        public static async Task ConfigureAsync()
        {
            var arr = new[] { Task.Run(FillClients), Task.Run(FillApiScopes), Task.Run(FillApiResources), Task.Run(FillClientResources) };
            Task.WaitAll(arr);
        }

        private static async Task FillApiResources()
        {
            using (var context = new AuthDbContext())
            {
                _apiResources = AutoMapperWrapper.Mapper.Map<List<ApiResourceResponse>>(
                    context.ApiResources.Where(w => w.Status == EntStatus.Active).Include(w => w.ApiResourceScopes));
            }
        }

        private static async Task FillApiScopes()
        {
            using (var context = new AuthDbContext())
            {
                _apiScopes = AutoMapperWrapper.Mapper.Map<List<ApiResourceScopeResponse>>(context.ApiResourceScopes);
            }
        }

        private static async Task FillClients()
        {
            using (var context = new AuthDbContext())
            {
                _clients = AutoMapperWrapper.Mapper.Map<List<ClientResponse>>(context.Clients.Where(w => w.Status == EntStatus.Active).Include(w => w.ClientScopes));
            }
        }

        private static async Task FillClientResources()
        {
            using (var context = new AuthDbContext())
            {
                _clientResources = AutoMapperWrapper.Mapper.Map<List<ClientApiResourceResponse>>(context.ClientApiResources.Where(w => w.Client.Status == EntStatus.Active && w.ApiResource.Status == EntStatus.Active).Include(w => w.ApiResource).Include(w => w.Client));
            }
        }

    }
}
