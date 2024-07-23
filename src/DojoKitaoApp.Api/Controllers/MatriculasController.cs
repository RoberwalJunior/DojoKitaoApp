using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MatriculasController(IMatriculaServiceApi matriculaService)
    : ControllerBase
{
    private readonly IMatriculaServiceApi service = matriculaService;

    [HttpGet]
    public async Task<IEnumerable<ReadMatriculaDto>> ListarMatriculasDosAlunos()
    {
        return await service.ListarAsMatriculasDosAlunos();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarMatriculaPeloId(int id)
    {
        var matricula = service.RecuperarMatriculaPeloId(id);
        return matricula != null ? Ok(matricula) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> NovaMatricula([FromBody] CreateMatriculaDto matriculaDto)
    {
        await service.CriarNovaMatricula(matriculaDto);
        return Ok($"Matricula criado com exito!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarMatricula(int id, [FromBody] UpdateMatriculaDto matriculaDto)
    {
        return await service.AtualizarMatricula(id, matriculaDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverMatricula(int id)
    {
        return await service.RemoverMatricula(id) ? NoContent() : NotFound();
    }
}
