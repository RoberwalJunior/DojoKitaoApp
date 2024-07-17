﻿using Microsoft.AspNetCore.Mvc;
using DojoKitaoApp.Libraries.Application.Interfaces;
//using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;

namespace DojoKitaoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KarateController(/*IAlunoServiceApi alunoService,*/ IMatriculaServiceApi matriculaService,
    ITreinoServiceApi treinoService, IAulaServiceApi aulaService) : ControllerBase
{
    //private readonly IAlunoServiceApi alunoService = alunoService;
    private readonly IMatriculaServiceApi matriculaService = matriculaService;
    private readonly ITreinoServiceApi treinoService = treinoService;
    private readonly IAulaServiceApi aulaService = aulaService;

    //[HttpGet("Alunos")]
    //public async Task<IEnumerable<ReadAlunoDto>> ListarTodosOsAlunos()
    //{
    //    return await alunoService.ListarTodosOsAlunosDaArteMarcial(1);
    //}

    [HttpGet("Matriculas")]
    public async Task<IEnumerable<ReadMatriculaDto>> ListarMatriculasDosAlunos()
    {
        return await matriculaService.ListarAsMatriculasDosAlunos(1);
    }

    [HttpGet("Treinos")]
    public async Task<IEnumerable<ReadTreinoDto>> ListarTreinos()
    {
        return await treinoService.ListarTodosOsTreinos(1);
    }

    [HttpGet("Aulas")]
    public async Task<IEnumerable<ReadAulaDto>> ListarAulas()
    {
        return await aulaService.ListarTodasAsAulas(1);
    }
}
