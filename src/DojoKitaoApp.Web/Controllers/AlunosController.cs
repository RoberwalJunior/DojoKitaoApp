using DojoKitaoApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Web.Interfaces.ServicesApi;

namespace DojoKitaoApp.Web.Controllers;

public class AlunosController(IAlunoServiceApi alunoService, IEnderecoServiceApi enderecoService) : Controller
{
    private readonly IAlunoServiceApi alunoService = alunoService;
    private readonly IEnderecoServiceApi enderecoService = enderecoService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var alunos = await alunoService.ListarAsync();
        return alunos != null ? View(alunos) : NotFound();
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cadastrar(AlunoEnderecoViewModel view)
    {
        if (!ModelState.IsValid)
        {
            return View(view);
        }

        var endereco = new EnderecoViewModel()
        {
            Logradouro = view.Logradouro,
            Numero = view.Numero,
            Complemento = view.Complemento,
            CEP = view.CEP
        };

        int idEndereco = await enderecoService.CriarEnderecoAsync(endereco);
        if (idEndereco <= 0)
        {
            ModelState.AddModelError("Cadastrar endereco", "Erro ao processar a solicitação");
            return View(view);
        }

        var aluno = new AlunoViewModel()
        {
            EnderecoId = idEndereco,
            Nome = view.Nome,
            Sobrenome = view.Sobrenome,
            DataNascimento = view.DataNascimento
        };

        if (!await alunoService.CriarAsync(aluno))
        {
            ModelState.AddModelError("Cadastrar aluno", "Erro ao processar a solicitação");
            return View(view);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var aluno = await alunoService.RecuperarPeloIdAsync(id);
        return aluno != null ? View(aluno) : NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(AlunoViewModel aluno)
    {
        if (!ModelState.IsValid)
        {
            return View(aluno);
        }

        if (!await alunoService.AlterarAsync(aluno.Id, aluno))
        {
            ModelState.AddModelError("Editar aluno", "Erro ao processar a solicitação");
            return View(aluno);
        }

        return RedirectToAction(nameof(Detalhes), new { id = aluno.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Detalhes(int id)
    {
        var aluno = await alunoService.RecuperarPeloIdAsync(id);
        return aluno != null ? View(aluno) : NotFound();
    }
}
