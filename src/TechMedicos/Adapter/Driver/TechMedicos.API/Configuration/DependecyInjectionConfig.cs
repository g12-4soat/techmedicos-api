using Amazon.DynamoDBv2;
using TechMedicos.Adapter.DynamoDB.Repositories;
using TechMedicos.Application.Controllers;
using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.Ports.Repositories;

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
            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                var config = new AmazonDynamoDBConfig
                {
                    RegionEndpoint = Amazon.RegionEndpoint.USEast1
                };
                return new AmazonDynamoDBClient(config);
            });
        }
    }
}
