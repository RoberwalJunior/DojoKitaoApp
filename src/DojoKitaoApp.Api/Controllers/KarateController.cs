using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DojoKitaoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KarateController(IAlunoServiceApi alunoService) : ControllerBase
{
    private readonly IAlunoServiceApi alunoService = alunoService;

    [HttpGet("Alunos")]
    public IEnumerable<ReadAlunoDto> ListarTodosOsAlunos()
    {
        return alunoService.ListarTodosOsAlunosDaArteMarcial(1);
    }
}
