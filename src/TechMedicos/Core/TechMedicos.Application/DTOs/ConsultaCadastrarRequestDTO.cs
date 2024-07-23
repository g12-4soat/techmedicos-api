using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para cadastro de consultas.
    /// </summary>
    public class ConsultaCadastrarRequestDTO
    {

        /// <summary>
        /// Id do Médico
        /// </summary>
        /// <example>1</example>
        public int MedicoId { get; set; }

        /// <summary>
        /// Id do Paciente
        /// </summary>
        /// <example>1</example>
        public int PacienteId { get; set; }

        /// <summary>
        /// Data da consulta
        /// </summary>
        /// <example>2024-07-21</example>
        public DateTime DataConsulta { get; set; }

        /// <summary>
        /// Valor da consulta
        /// </summary>
        /// <example>500.0</example>
        public decimal Valor { get; set; }
    }
}
