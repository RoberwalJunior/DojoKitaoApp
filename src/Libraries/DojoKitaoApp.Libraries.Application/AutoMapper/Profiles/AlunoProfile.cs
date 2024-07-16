using AutoMapper;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aluno;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<CreateAlunoDto, Aluno>();
        CreateMap<Aluno, ReadAlunoDto>();
        CreateMap<UpdateAlunoDto, Aluno>();
    }
}
