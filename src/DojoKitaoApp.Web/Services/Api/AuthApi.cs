using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Services.Api;

public class AuthApi(IHttpClientFactory factory) : IAuthApi
{
    private readonly HttpClient httpClient = factory.CreateClient("API");

    public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
    {
        var result = await httpClient.PostAsJsonAsync("auth/Login?useCookies=true", new
        {
            email = loginViewModel.Email,
            password = loginViewModel.Senha
        });
        return result.IsSuccessStatusCode;
    }
}
