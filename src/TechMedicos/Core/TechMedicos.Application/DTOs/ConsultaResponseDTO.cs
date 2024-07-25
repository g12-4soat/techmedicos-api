using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para retorno de consultas.
    /// </summary>
    public class ConsultaResponseDTO
    {
        /// <summary>
        /// Id da Consulta
        /// </summary>
        /// <example>1</example>
        public string Id { get; set; }
        /// <summary>
        /// Id do Médico
        /// </summary>
        /// <example>1</example>
        public string MedicoId { get; set; }

        public MedicoResponseDTO Medico { get; set; }

        /// <summary>
        /// Id do Paciente
        /// </summary>
        /// <example>1</example>
        public string PacienteId { get; set; }

        public PacienteResponseDTO Paciente { get; set; }

        /// <summary>
        /// Data da consulta
        /// </summary>
        /// <example>2024-07-21 09:00</example>
        public DateTime DataConsulta { get; set; }

        /// <summary>
        /// Status da consulta
        /// </summary>
        /// <example>Agendada</example>
        public string Status { get; set; }

        /// <summary>
        /// Valor da consulta
        /// </summary>
        /// <example>500.0</example>
        public decimal Valor { get; set; }
    }
}
