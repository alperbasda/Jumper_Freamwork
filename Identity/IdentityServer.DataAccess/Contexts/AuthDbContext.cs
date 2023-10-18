using IdentityServer.Entities.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MsSqlAdapter.Context;
using ServerBaseContract;
using Tools.DIHelper;

namespace IdentityServer.DataAccess.Contexts
{
    public class AuthDbContext : MsSqlDbContext
    {
        protected override DatabaseOptions Options { get; set; }

        public AuthDbContext() : base()
        {
            Options = ServiceTools.ServiceProvider.GetService<DatabaseOptions>();
        }

        //public AuthDbContext(DatabaseOptions options)
        //{
        //    Options = options;
        //}

        public virtual DbSet<ApiResource> ApiResources { get; set; }

        public virtual DbSet<ApiResourceScope> ApiResourceScopes { get; set; }

        public virtual DbSet<AuthMessage> AuthMessages { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<ClientApiResource> ClientApiResources { get; set; }

        public virtual DbSet<ClientScope> ClientScopes { get; set; }

        public virtual DbSet<IdentityUser> IdentityUsers { get; set; }

        public virtual DbSet<IdentityUserPassword> IdentityUserPasswords { get; set; }

        public virtual DbSet<IdentityUserRefreshToken> IdentityUserRefreshTokens { get; set; }

        public virtual DbSet<IdentityUserRole> IdentityUserRoles { get; set; }

        public virtual DbSet<IdentityUserScope> IdentityUserScopes { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<RoleScope> RoleScopes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuthDbContextInitializer.Init(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
