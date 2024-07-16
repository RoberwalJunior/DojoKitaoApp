using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

namespace DojoKitaoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController(IAlunoServiceApi service) : ControllerBase
{
    private readonly IAlunoServiceApi service = service;

    [HttpGet]
    public IEnumerable<ReadAlunoDto> ListarAlunos()
    {
        return service.ListarTodosOsAlunos();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarAluno(int id)
    {
        var alunoDto = service.RecuperarAlunoPeloId(id);
        return alunoDto != null ? Ok(alunoDto) : NotFound();
    }

    [HttpGet("{id}/Matricula")]
    public IActionResult RecuperarMatriculaDoAluno(int id)
    {
        var matriculaDto = service.RecuperarMatriculaDoAluno(id);
        return matriculaDto != null ? Ok(matriculaDto) : NotFound();
    }

    [HttpPost]
    public IActionResult CriarNovoAluno([FromBody] CreateAlunoDto alunoDto)
    {
        service.CriarNovoAluno(alunoDto);
        return Ok($"Aluno {alunoDto.Nome} criado com exito!");
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarAluno(int id, [FromBody] UpdateAlunoDto alunoDto)
    {
        return service.AtualizarAluno(id, alunoDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarAluno(int id)
    {
        return service.RemoverAluno(id) ? NoContent() : NotFound();
    }
}
