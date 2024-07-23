using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para cadastro dos horários da Agenda Médica.
    /// </summary>
    public class HorarioDisponivelRequestDTO
    {
        /// <summary>
        /// Hora de início.
        /// </summary>
        /// <example>09:00</example>
        public DateOnly HoraInicio { get; set; }        
    }
}
