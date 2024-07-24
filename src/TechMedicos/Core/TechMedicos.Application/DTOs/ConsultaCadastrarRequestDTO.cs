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
        public string MedicoId { get; set; }

        /// <summary>
        /// Id do Paciente
        /// </summary>
        /// <example>1</example>
        public string PacienteId { get; set; }

        /// <summary>
        /// Data da consulta
        /// </summary>
        /// <example>2024-07-21 09:00</example>
        public DateTime DataConsulta { get; set; }
    }
}
