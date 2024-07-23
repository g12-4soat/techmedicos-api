using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para cadastro de Agenda Médica.
    /// </summary>
    public class AgendaMedicaRequestDTO
    {
        /// <summary>
        /// Data da agenda médica.
        /// </summary>
        /// <example>2024-07-22</example>
        public DateOnly Data { get; set; }

        public List<HorarioDisponivelRequestDTO> Horarios { get; set; }
    }
}
