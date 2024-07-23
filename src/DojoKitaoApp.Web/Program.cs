using DojoKitaoApp.Web.Services.Api;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEnderecoServiceApi, EnderecoServiceApi>();
builder.Services.AddScoped<IAuthApi, AuthApi>();

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
