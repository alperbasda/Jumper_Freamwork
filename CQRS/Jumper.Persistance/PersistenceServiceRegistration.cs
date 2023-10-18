using Core.Persistence.Models;
using Jumper.Application.Services.Repositories;
using Jumper.Persistance.Contexts;
using Jumper.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jumper.Persistance;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        #region Db Options

        DatabaseOptions opts = new DatabaseOptions();

        configuration.GetSection("DatabaseOptions").Bind(opts);
        services.Configure<DatabaseOptions>(options =>
        {
            options = opts;
        });
        services.AddSingleton(sp =>
        {
            return opts;
        });


        #endregion

        services.AddDbContext<JumperDbContext>(options => options.UseSqlServer(opts.EfConnectionString));

        services.AddScoped<IProjectDeclarationDal, ProjectDeclarationDal>();
        services.AddScoped<IEntityDefinitionDal, EntityDefinitionDal>();
        services.AddScoped<IEntityPropertyDefinitionDal, EntityPropertyDefinitionDal>();
        services.AddScoped<IPropertyTypeDeclarationDal, PropertyTypeDeclarationDal>();
        services.AddScoped<IProjectEntityDal, ProjectEntityDal>();
        services.AddScoped<IProjectEntityActionDal, ProjectEntityActionDal>();
        services.AddScoped<IProjectEntityActionPropertyDal, ProjectEntityActionPropertyDal>();
        services.AddScoped<IProjectEntityDependencyDal, ProjectEntityDependencyDal>();
        services.AddScoped<IProjectEntityPropertyDal, ProjectEntityPropertyDal>();
        services.AddScoped<IArchitectureDefinitionDal, ArchitectureDefinitionDal>();
        
        return services;
    }
}
