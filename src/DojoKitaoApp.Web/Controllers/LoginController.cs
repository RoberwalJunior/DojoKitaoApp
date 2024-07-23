using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Interfaces.ServicesApi;
using Microsoft.AspNetCore.Mvc;

namespace DojoKitaoApp.Web.Controllers;

public class LoginController(IAuthApi service) : Controller
{
    private readonly IAuthApi service = service;

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
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
}
