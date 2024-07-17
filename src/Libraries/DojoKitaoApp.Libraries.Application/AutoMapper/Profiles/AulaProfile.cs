using AutoMapper;
using DojoKitaoApp.Libraries.Application.AutoMapper.Dtos.Aula;
using DojoKitaoApp.Libraries.Domain.Entities;

namespace DojoKitaoApp.Libraries.Application.AutoMapper.Profiles;

public class AulaProfile : Profile
{
    public AulaProfile()
    {
        CreateMap<CreateAulaDto, Aula>();
        CreateMap<Aula, ReadAulaDto>();
        CreateMap<UpdateAulaDto, Aula>();
    }
}
