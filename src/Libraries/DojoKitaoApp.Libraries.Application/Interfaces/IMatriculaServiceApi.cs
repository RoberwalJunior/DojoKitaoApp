﻿using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Libraries.Application.Interfaces;

public interface IMatriculaServiceApi
{
    public IEnumerable<ReadMatriculaDto> ListarAsMatriculasDosAlunos();
    public void CriarNovaMatricula(CreateMatriculaDto matriculaDto);
    public bool AtualizarMatricula(int id, UpdateMatriculaDto matriculaDto);
}
