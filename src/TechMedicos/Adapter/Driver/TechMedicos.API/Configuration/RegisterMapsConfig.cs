using Mapster;
using System.Reflection;
using TechMedicos.Adapter.DynamoDB.Models;
using TechMedicos.Application.DTOs;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.Enums;
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

            TypeAdapterConfig<PacienteDbModel, Paciente>
            .NewConfig()
            .ConstructUsing(src => new Paciente(src.Id, src.Nome, src.Cpf, src.Email));

            TypeAdapterConfig<MedicoDbModel, Medico>
            .NewConfig()
            .ConstructUsing(src => new Medico(src.Id, src.Nome, src.Crm, src.ValorConsulta, src.Agendamentos));

            TypeAdapterConfig<Consulta, ConsultaResponseDTO>
           .NewConfig()
           .Map(dest => dest.Medico, src => src.Medico.Adapt<ConsultaMedicoResponseDTO>())
           .Map(dest => dest.Paciente, src => src.Paciente.Adapt<PacienteResponseDTO>());

            TypeAdapterConfig<Crm, string>.NewConfig()
            .MapWith(crm => crm.Documento);

            TypeAdapterConfig<Cpf, string>.NewConfig()
           .MapWith(cpf => cpf.Numero);

            TypeAdapterConfig<Email, string>.NewConfig()
           .MapWith(email => email.EnderecoEmail);

            TypeAdapterConfig<StatusConsulta, string>.NewConfig()
           .MapWith(status => status.ToString());

            TypeAdapterConfig<Crm, string>.NewConfig()
            .MapWith(crm => crm.Documento);

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
