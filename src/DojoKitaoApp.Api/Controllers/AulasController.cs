using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;

namespace DojoKitaoApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AulasController(IAulaServiceApi serviceApi) : ControllerBase
{
    private readonly IAulaServiceApi service = serviceApi;

    [HttpGet]
    public async Task<IEnumerable<ReadAulaDto>> ListarAulas()
    {
        return await service.ListarTodasAsAulas();
    }

    [HttpGet("{treinoId}/{alunoId}")]
    public IActionResult RecuperarAula(int treinoId, int alunoId)
    {
        var aulaDto = service.RecuperarAulaPeloTreinoIdAlunoId(treinoId, alunoId);
        return aulaDto != null ? Ok(aulaDto) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CriarNovaAula([FromBody] CreateAulaDto aulaDto)
    {
        await service.CriarNovaAula(aulaDto);
        return Ok("Aula criado com exito!");
    }
}
