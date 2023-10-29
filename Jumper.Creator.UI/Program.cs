using Jumper.Application;
using Jumper.Creator.UI.Middlewares;
using Jumper.Persistance;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Jumper.Creator.UI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddWebServices(builder.Configuration);

builder.Services.AddSession();

builder.Services.AddSingleton<IDataProtectionProvider>(s => DataProtectionProvider.Create("Jumper"));

builder.Services.Configure<CookieTempDataProviderOptions>(options =>
{
    
});
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandlerMiddleware();
app.UseSession();
app.UseCookiePolicy();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
