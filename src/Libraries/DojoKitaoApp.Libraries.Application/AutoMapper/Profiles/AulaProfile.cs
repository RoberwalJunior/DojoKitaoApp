using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;
using DojoKitaoApp.Libraries.Domain.Entities;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;

public class AulaProfile : Profile
{
    public AulaProfile()
    {
        CreateMap<CreateAulaDto, Aula>()
            .ForMember(aula => aula.Data,
                opt => opt.MapFrom(aulaDto => DateTime.Parse(aulaDto.Data!)));
        CreateMap<Aula, ReadAulaDto>();
        CreateMap<UpdateAulaDto, Aula>();
    }
}
