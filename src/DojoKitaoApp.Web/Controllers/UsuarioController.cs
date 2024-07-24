using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Web.Interfaces.ServicesApi;
using DojoKitaoApp.Web.Models;

namespace DojoKitaoApp.Web.Controllers;

public class UsuarioController(IAuthApi service) : Controller
{
    private readonly IAuthApi service = service;

    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("Login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }

        if (!await service.LoginAsync(login))
        {
            ModelState.AddModelError("Login", "Login/senha inválidos");
            return View(login);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        if (await service.VerificaAutenticado())
        {
            await service.LogoutAsync();
        }
        return RedirectToAction("Index", "Home");
    }
}
