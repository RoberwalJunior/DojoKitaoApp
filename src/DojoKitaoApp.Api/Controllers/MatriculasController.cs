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
    public IEnumerable<ReadMatriculaDto> ListarMatriculasDosAlunos()
    {
        return service.ListarAsMatriculasDosAlunos();
    }

    [HttpPost]
    public IActionResult NovaMatricula([FromBody] CreateMatriculaDto matriculaDto)
    {
        service.CriarNovaMatricula(matriculaDto);
        return Ok($"Matricula criado com exito!");
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarMatricula(int id, [FromBody] UpdateMatriculaDto matriculaDto)
    {
        return service.AtualizarMatricula(id, matriculaDto) ? NoContent() : NotFound();
    }
}
