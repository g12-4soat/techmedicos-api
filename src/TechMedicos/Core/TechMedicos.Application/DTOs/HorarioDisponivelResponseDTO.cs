using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMedicos.Application.DTOs
{
    /// <summary>
    /// Schema utilizado para retorno dos horários da Agenda Médica.
    /// </summary>
    public class HorarioDisponivelResponseDTO
    {
        /// <summary>
        /// Hora inicial.
        /// </summary>
        /// <example>09:00</example>
        public TimeOnly HoraInicio { get; private set; }

        /// <summary>
        /// Hora final.
        /// </summary>
        /// <example>09:50</example>
        public TimeOnly HoraFim { get; private set; }
    }
}
