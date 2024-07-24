using TechMedicos.API.Endpoints;

namespace TechMedicos.API.Configuration
{
    public static class MapEndpointsConfig
    {
        public static void UseMapEndpointsConfiguration(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapConsultaEndpoints();
            endpoints.MapMedicoEndpoints();
        }
    }
}
