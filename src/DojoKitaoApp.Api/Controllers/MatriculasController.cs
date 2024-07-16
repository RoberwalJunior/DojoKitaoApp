using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Api.Controllers;

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
}
