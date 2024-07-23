using DojoKitaoApp.Web.Services.Api;
using DojoKitaoApp.Web.Interfaces.ServicesApi;
using DojoKitaoApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CookieHandler>();
builder.Services.AddScoped<IEnderecoServiceApi, EnderecoServiceApi>();
builder.Services.AddScoped<IAuthApi, AuthApi>();

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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
