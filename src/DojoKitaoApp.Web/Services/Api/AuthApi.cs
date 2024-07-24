using System.Security.Claims;
using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Models.Response;
using DojoKitaoApp.Web.Interfaces.ServicesApi;
using Microsoft.AspNetCore.Components.Authorization;

namespace DojoKitaoApp.Web.Services.Api;

public class AuthApi(IHttpClientFactory factory) : AuthenticationStateProvider, IAuthApi
{
    private readonly HttpClient httpClient = factory.CreateClient("API");

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var pessoa = new ClaimsPrincipal();
        var response = await httpClient.GetAsync("auth/manage/info");

        if (response.IsSuccessStatusCode)
        {
            var info = await response.Content.ReadFromJsonAsync<InfoPessoaResponse>();
            if (info != null)
            {
                Claim[] dados =
                    [
                        new Claim(ClaimTypes.Name, info.Email!),
                    new Claim(ClaimTypes.Email, info.Email!)
                    ];
                var identity = new ClaimsIdentity(dados, "Cookies");
                pessoa = new ClaimsPrincipal(identity);
            }
        }
        return new AuthenticationState(pessoa);
    }

    public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
    {
        var result = await httpClient.PostAsJsonAsync("auth/Login?useCookies=true", new
        {
            email = loginViewModel.Email,
            password = loginViewModel.Senha
        });

        if (result.IsSuccessStatusCode)
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        return result.IsSuccessStatusCode;
    }
}
