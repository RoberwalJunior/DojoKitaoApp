using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Web.Models;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Controllers;

public class EnderecosController(IEnderecoServiceApi service) : Controller
{
    private readonly IEnderecoServiceApi service = service;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var enderecos = await service.ListarAsync();
        return enderecos != null ? View(enderecos) : NotFound();
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cadastrar(EnderecoViewModel endereco)
    {
        if (!ModelState.IsValid)
        {
            return View(endereco);
        }
        return VerificarSolicitacao(await service.CriarAsync(endereco), "Cadastrar Endereco");
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        return await RecuperarPeloId(id);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(EnderecoViewModel endereco)
    {
        if (!ModelState.IsValid)
        {
            return View(endereco);
        }

        return VerificarSolicitacao(await service.AlterarAsync(endereco.Id, endereco), "Atualizar Endereco");
    }

    [HttpGet]
    public async Task<IActionResult> Detalhes(int id)
    {
        return await RecuperarPeloId(id);
    }

    private RedirectToActionResult VerificarSolicitacao(bool resultado, string acao)
    {
        if (!resultado)
        {
            ModelState.AddModelError(acao, "Erro ao processar a solicitação");
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<IActionResult> RecuperarPeloId(int id)
    {
        var endereco = await service.RecuperarPeloIdAsync(id);
        return endereco != null ? View(endereco) : NotFound();
    }
}
