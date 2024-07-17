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
    public async Task<IEnumerable<ReadAlunoDto>> ListarAlunos()
    {
        return await service.ListarTodosOsAlunos();
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
        var matriculaDto = service.RecuperarMatriculasDoAluno(id);
        return matriculaDto != null ? Ok(matriculaDto) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CriarNovoAluno([FromBody] CreateAlunoDto alunoDto)
    {
        await service.CriarNovoAluno(alunoDto);
        return Ok($"Aluno {alunoDto.Nome} criado com exito!");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarAluno(int id, [FromBody] UpdateAlunoDto alunoDto)
    {
        return await service.AtualizarAluno(id, alunoDto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarAluno(int id)
    {
        return await service.RemoverAluno(id) ? NoContent() : NotFound();
    }
}
