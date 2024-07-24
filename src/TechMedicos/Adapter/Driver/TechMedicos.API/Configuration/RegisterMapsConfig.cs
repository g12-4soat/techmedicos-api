using Mapster;
using System.Reflection;
using TechMedicos.Application.DTOs;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.API.Configuration
{
    public static class RegisterMapsConfig
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<HorarioDisponivelRequestDTO, HorarioDisponivel>
            .NewConfig()
            .ConstructUsing(src => new HorarioDisponivel(src.HoraInicio));

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
