namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para retorno de consultas.
    /// </summary>
    public class ConsultaResponseDTO
    {
        /// <summary>
        /// Id do Médico
        /// </summary>
        /// <example>1</example>
        public string MedicoId { get; set; }

        /// <summary>
        /// Id do Paciente
        /// </summary>
        /// <example>1</example>
        public string PacienteId { get; set; }

        /// <summary>
        /// Data da consulta
        /// </summary>
        /// <example>2024-07-21</example>
        public DateTime DataConsulta { get; set; }

        /// <summary>
        /// Status da consulta
        /// </summary>
        /// <example>Agendada</example>
        //public StatusConsulta Status { get; set; }

        /// <summary>
        /// Valor da consulta
        /// </summary>
        /// <example>500.0</example>
        public decimal Valor { get; set; }
    }
}
