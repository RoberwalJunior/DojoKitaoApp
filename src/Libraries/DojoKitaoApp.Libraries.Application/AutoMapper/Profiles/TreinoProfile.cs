using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Treino;
using DojoKitaoApp.Libraries.Domain.Entities;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;

public class TreinoProfile : Profile
{
    public TreinoProfile()
    {
        CreateMap<CreateTreinoDto, Treino>();
        CreateMap<Treino, ReadTreinoDto>()
            .ForMember(treinoDto => treinoDto.ArteMarcial,
                opt => opt.MapFrom(treino => treino.ArteMarcial.ToString()));
        CreateMap<UpdateTreinoDto, Treino>();
    }
}
