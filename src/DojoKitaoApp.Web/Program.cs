using DojoKitaoApp.Web.Services;
using DojoKitaoApp.Web.Services.Api;
using DojoKitaoApp.Web.Interfaces.ServicesApi;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthApi>();
builder.Services.AddScoped<IAuthApi, AuthApi>(sp => (AuthApi)
    sp.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddScoped<CookieHandler>();
builder.Services.AddScoped<IEnderecoServiceApi, EnderecoServiceApi>();
builder.Services.AddScoped<IAlunoServiceApi, AlunoServiceApi>();

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AppConfig:EndPoints:DojoKitaoApi"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddHttpMessageHandler<CookieHandler>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
