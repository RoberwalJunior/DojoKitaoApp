using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DojoKitaoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AikidoController(IAlunoServiceApi alunoService, IMatriculaServiceApi matriculaService)
    : ControllerBase
{
    private readonly IAlunoServiceApi alunoService = alunoService;
    private readonly IMatriculaServiceApi matriculaService = matriculaService;

    [HttpGet("Alunos")]
    public IEnumerable<ReadAlunoDto> ListarTodosOsAlunos()
    {
        return alunoService.ListarTodosOsAlunosDaArteMarcial(0);
    }
}
