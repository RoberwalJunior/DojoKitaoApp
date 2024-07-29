using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Controllers;

public class AlunosController(IAlunoServiceApi service) : Controller
{
    private readonly IAlunoServiceApi service = service;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var alunos = await service.ListarAsync();
        return alunos != null ? View(alunos) : NotFound();
    }
}
