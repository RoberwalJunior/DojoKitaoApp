using AutoMapper;
using DojoKitaoApp.Libraries.Domain.Entities;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Matricula;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;

public class MatriculaProfile : Profile
{
    public MatriculaProfile()
    {
        CreateMap<CreateMatriculaDto, Matricula>();
        CreateMap<Matricula, ReadMatriculaDto>()
            .ForMember(matriculaDto => matriculaDto.ArteMarcial,
                opt => opt.MapFrom(matricula => matricula.ArteMarcial.ToString()));
        CreateMap<UpdateMatriculaDto, Matricula>();
    }
}
