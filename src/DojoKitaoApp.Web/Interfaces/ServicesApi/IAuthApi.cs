using DojoKitaoApp.Web.Models;

namespace DojoKitaoApp.Web.Interfaces.ServicesApi;

public interface IAuthApi
{
    Task<bool> LoginAsync(LoginViewModel loginViewModel);
    Task LogoutAsync();
    Task<string> GetIdentityName();
    Task<bool> VerificaAutenticado();
}
