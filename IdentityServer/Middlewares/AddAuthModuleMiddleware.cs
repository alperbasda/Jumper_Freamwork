using IdentityServer.Business.Concrete;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.Handler;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Concrete;
using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using MsSqlAdapter.Context;
using MsSqlAdapter.Repository;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Middlewares
{
    public static class AddAuthModuleMiddleware
    {
        public static IServiceCollection AddAuthModule(this IServiceCollection services,IConfiguration configuration)
        {

            #region Dependencies Added
 
            services.AddScoped((IServiceProvider provider) =>
            {
                return new AuthDbContext();
            });
            services.AddScoped<MsSqlDbContext, AuthDbContext>((IServiceProvider provider) =>
            {
                return provider.GetService<AuthDbContext>();
            });
            services.AddScoped<DbContext, AuthDbContext>((IServiceProvider provider) =>
            {
                return provider.GetService<AuthDbContext>();
            });
            services.AddScoped(typeof(IQueryableRepositoryBase<>), typeof(MsSqlQueryableRepositoryBase<>));
            
            
            
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IBaseService<,,,>),typeof(BaseService<,,,>));
            services.AddScoped<IApiResourceService, ApiResourceManager>();
            services.AddScoped<IApiResourceScopeService, ApiResourceScopeManager>();
            services.AddScoped<IClientService, ClientManager>();
            services.AddScoped<IClientScopeService, ClientScopeManager>();
            services.AddScoped<IAuthMessageService, AuthMessageManager>();
            services.AddScoped<IClientApiResourceService, ClientApiResourceManager>();


            services.AddScoped<IRoleScopeService, RoleScopeManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IIdentityUserScopeService, IdentityUserScopeManager>();
            services.AddScoped<IIdentityUserRoleService, IdentityUserRoleManager>();
            services.AddScoped<IIdentityUserService, IdentityUserManager>();
            services.AddScoped<IIdentityUserPasswordService, IdentityUserPasswordManager>();
            services.AddScoped<IIdentityUserRefreshTokenService, IdentityUserRefreshTokenManager>();

            services.AddScoped<IAuthenticationService, AuthenticationManager>();
            services.AddScoped<ITokenService, TokenManager>();
            


            services.AddScoped<IApiResourceDal, ApiResourceDal>();
            services.AddScoped<IApiResourceScopeDal, ApiResourceScopeDal>();
            services.AddScoped<IClientDal, ClientDal>();
            services.AddScoped<IClientScopeDal, ClientScopeDal>();
            services.AddScoped<IAuthMessageDal, AuthMessageDal>();

            services.AddScoped<IRoleScopeDal, RoleScopeDal>();
            services.AddScoped<IRoleDal, RoleDal>();
            services.AddScoped<IIdentityUserScopeDal, IdentityUserScopeDal>();
            services.AddScoped<IIdentityUserRoleDal, IdentityUserRoleDal>();
            services.AddScoped<IIdentityUserDal, IdentityUserDal>();
            services.AddScoped<IIdentityUserPasswordDal, IdentityUserPasswordDal>();
            services.AddScoped<IIdentityUserRefreshTokenDal, IdentityUserRefreshTokenDal>();
            services.AddScoped<IClientApiResourceDal, ClientApiResourceDal>();

            services.AddScoped<TokenDelegateHandler>();

            #endregion
            return services;
        }

    }
}
