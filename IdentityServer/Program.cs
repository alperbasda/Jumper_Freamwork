using AutoMapperAdapter;
using FluentValidation.AspNetCore;
using FluentValidationAdapter.Middlewares;
using IdentityServer.Business.Constants;
using IdentityServer.Entities.Poco;
using IdentityServer.Middlewares;
using JwtHelpers.Models;
using IdentityServer.Policies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MsSqlAdapter.Middlewares;
using ServerBaseContract;
using System.Reflection;
using Tools.DIHelper;
using UIHelpers.ActionFilters;
using UIHelpers.Middlewares;
using Serilog;
using SeriLogAdapter.Middlewares;
using SeriLogAdapter;
using IdentityServer.Business.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(config => config.ClearProviders()).UseSerilog();
ElasticOptions elk = new ElasticOptions();

builder.Configuration.GetSection("ElasticConfiguration").Bind(elk);

builder.Services.AddSerilog(elk);
builder.Host.ConfigureAppConfiguration(configuration =>
{
    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    configuration.AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true);
});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity Server Api", Version = "v1" });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ModelValidatorAttribute));
});

#region Add Fluent Validation

builder.Services.AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    builder.Services.AddFluentValidationWrapper(options, Assembly.Load("IdentityServer.Business"));
});

builder.Services.Configure<ApiBehaviorOptions>(options => {
    options.SuppressModelStateInvalidFilter = true;
});

#endregion

#region Options

builder.Services.Configure<IdentityServerOptions>(options =>
{
    builder.Configuration.GetSection("Options").Bind(options);
});
builder.Services.AddSingleton<IdentityServerOptions>(sp =>
{
    return sp.GetRequiredService<IOptions<IdentityServerOptions>>().Value;
});


#endregion

#region DatabaseConfigurations

builder.Services.Configure<DatabaseOptions>(options =>
{
    builder.Configuration.GetSection("DatabaseOptions").Bind(options);
});
builder.Services.AddSingleton<DatabaseOptions>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;
});

#endregion

#region JwtConfigurations

builder.Services.Configure<JwtOptions>(options =>
{
    builder.Configuration.GetSection("TokenOptions").Bind(options);
});
builder.Services.AddSingleton<JwtOptions>(sp =>
{
    return sp.GetRequiredService<IOptions<JwtOptions>>().Value;
});

#endregion

builder.Services.AddMsSqlAdapter(new DatabaseOptions
{
    MsSqlConnectionString = builder.Configuration["DatabaseOptions:MsSqlConnectionString"],
    DatabaseName = builder.Configuration["DatabaseOptions:DatabaseName"]
});



AutoMapperWrapper.Configure(Assembly.Load("IdentityServer.Entities"));

builder.Services.AddJwtAuthentication(builder.Configuration.GetSection("TokenOptions").Get<JwtOptions>());


builder.Services.AddAuthorization(_ =>
{
    PolicySettings policySettings = builder.Configuration.GetSection("PolicySettings").Get<PolicySettings>();
    foreach (var item in policySettings.Policies)
    {
        _.AddPolicy(item.Key, policy => policy.RequireClaim("scope", item.Value));
    }
    
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

ServiceTools.Create(builder.Services);

/// <summary>
/// TODO : Database Update edilirken bunu yoruma almak lazým.
/// </summary>
await AuthConfig.ConfigureAsync();

//builder.Services.AddRabbitMqModules(builder.Configuration);

builder.Services.AddAuthModule(builder.Configuration);
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

AuthMessageManager.Initialize();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

/// <summary>
/// Exception fýrladýgýnda hatayý döner.
/// </summary>
app.UseApiExceptionMiddleware();

app.UseCors("corsapp");

app.UseAuthentication();
app.UseAuthorization();
/// <summary>
/// TokenParameters DI geçilirse bilgiler dolu gelecektir. Ayný zamanda httpcontext.User ý doldurur.
/// </summary>
app.UseJwtParameters();

app.MapControllers();

app.Run();
