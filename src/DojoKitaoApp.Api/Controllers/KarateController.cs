using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KarateController(IAlunoServiceApi alunoService, IMatriculaServiceApi matriculaService) : ControllerBase
{
    private readonly IAlunoServiceApi alunoService = alunoService;
    private readonly IMatriculaServiceApi matriculaService = matriculaService;

    [HttpGet("Alunos")]
    public async Task<IEnumerable<ReadAlunoDto>> ListarTodosOsAlunos()
    {
        return await alunoService.ListarTodosOsAlunosDaArteMarcial(1);
    }

    [HttpGet("Matriculas")]
    public async Task<IEnumerable<ReadMatriculaDto>> ListarMatriculasDosAlunos()
    {
        return await matriculaService.ListarAsMatriculasDosAlunos(1);
    }
}
