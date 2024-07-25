using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para atualização de consultas.
    /// </summary>
    public class ConsultaAtualizarRequestDTO
    {

        /// <summary>
        /// Status da consulta
        /// </summary>
        /// <example>Agendada</example>
        public StatusConsulta Status { get; set; }

        /// <summary>
        /// Justificativa de cancelamento da consulta
        /// </summary>
        /// <example>1</example>
        public string Justificativa { get; set; }
    }
}
