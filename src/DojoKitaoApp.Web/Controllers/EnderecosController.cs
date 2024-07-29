using DojoKitaoApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Controllers;

public class EnderecosController(IEnderecoServiceApi service) : Controller
{
    private readonly IEnderecoServiceApi service = service;

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var endereco = await service.RecuperarPeloIdAsync(id);
        return endereco != null ? View(endereco) : NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(EnderecoViewModel endereco)
    {
        if (!ModelState.IsValid)
        {
            return View(endereco);
        }

        if (!await service.AlterarAsync(endereco.Id, endereco))
        {
            ModelState.AddModelError("Atualizar Endereco", "Erro ao processar a solicitação");
            return View(endereco);
        }

        return RedirectToAction("Detalhes", "Alunos", new { id = endereco.AlunoId });
    }
}
