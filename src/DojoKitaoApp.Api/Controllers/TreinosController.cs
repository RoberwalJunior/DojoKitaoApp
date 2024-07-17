using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;

namespace DojoKitaoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreinosController(ITreinoServiceApi serviceApi) : ControllerBase
{
    private readonly ITreinoServiceApi service = serviceApi;

    [HttpGet]
    public async Task<IEnumerable<ReadTreinoDto>> ListarTreinos()
    {
        return await service.ListarTodosOsTreinos();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarTreino(int id)
    {
        var treinoDto = service.RecuperarTreinoPeloId(id);
        return treinoDto != null ? Ok(treinoDto) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CriarTreino([FromBody] CreateTreinoDto treinoDto)
    {
        await service.CriarNovoTreino(treinoDto);
        return Ok($"Treino criado com exito!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTreino(int id, [FromBody] UpdateTreinoDto treinoDto)
    {
        return await service.AtualizarTreino(id, treinoDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarTreino(int id)
    {
        return await service.RemoverTreino(id) ? NoContent() : NotFound();
    }
}
