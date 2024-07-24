using TechMedicos.Adapter.DynamoDB.Repositories;
using TechMedicos.Application.Controllers;
using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Core;

namespace TechMedicos.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IConsultaController, ConsultaController>();
            services.AddScoped<IMedicoController, MedicoController>();

            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
        }
    }
}
