using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Services.Api;

public class AuthApi : IAuthApi
{
    private readonly string ENDPOINT;
    private readonly HttpClient httpClient;

    public AuthApi(IConfiguration configuration)
    {
        ENDPOINT = configuration["AppConfig:EndPoints:DojoKitaoApi"] + "auth/Login/";
        httpClient = new HttpClient
        {
            BaseAddress = new Uri(ENDPOINT)
        };
    }

    public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
    {
        var result = await httpClient.PostAsJsonAsync(ENDPOINT, new
        {
            email = loginViewModel.Email,
            password = loginViewModel.Senha
        });
        return result.IsSuccessStatusCode;
    }
}
