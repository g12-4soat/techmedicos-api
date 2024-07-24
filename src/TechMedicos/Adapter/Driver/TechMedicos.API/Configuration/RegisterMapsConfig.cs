using Mapster;
using System.Reflection;
using TechMedicos.Application.DTOs;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.API.Configuration
{
    public static class RegisterMapsConfig
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            // Mapeamento de AgendaMedica para AgendaMedicaResponseDTO
            TypeAdapterConfig<AgendaMedica, AgendaMedicaResponseDTO>.NewConfig()
                .Map(dest => dest.Data, src => src.Data)
                .Map(dest => dest.Horarios, src => src.Horarios.Select(h => h.Adapt<HorarioDisponivelResponseDTO>()).ToList());

            // Mapeamento de HorarioDisponivel para HorarioDisponivelResponseDTO
            TypeAdapterConfig<HorarioDisponivel, HorarioDisponivelResponseDTO>.NewConfig()
                .Map(dest => dest.HoraInicio, src => src.HoraInicio)
                .Map(dest => dest.HoraFim, src => src.HoraFim);

            TypeAdapterConfig<HorarioDisponivelRequestDTO, HorarioDisponivel>
            .NewConfig()
            .ConstructUsing(src => new HorarioDisponivel(src.HoraInicio));

            TypeAdapterConfig<Crm, string>.NewConfig()
            .MapWith(crm => crm.Documento);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
