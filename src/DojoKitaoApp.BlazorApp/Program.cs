using DojoKitaoApp.BlazorApp;
using DojoKitaoApp.BlazorApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AppConfig:EndPoints:DojoKitaoApi"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<EnderecoAPI>();
builder.Services.AddScoped<AlunoAPI>();

await builder.Build().RunAsync();
