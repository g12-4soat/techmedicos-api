using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para retorno de Agenda Médica.
    /// </summary>
    public class AgendaMedicaResponseDTO
    {
        /// <summary>
        /// Data da agenda médica.
        /// </summary>
        /// <example>2024-07-22</example>
        public DateOnly Data { get; set; }

        /// <summary>
        /// Valor da consulta médica.
        /// </summary>
        /// <example>100</example>
        public decimal ValorConsulta { get; set; }

        public List<HorarioDisponivelResponseDTO> Horarios { get; set; }
    }
}
