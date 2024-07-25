using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Application.DTOs
{
    public class MedicoResponseDTO
    {
        public string Id { get; set; }
        public List<AgendaMedicaResponseDTO>? Agendas { get; set; }
        public string Crm { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Nome { get; set; }
    }
}
