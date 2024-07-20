using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Application.DTOs;

namespace TechMedicos.Application.Controllers.Interfaces
{
    public interface IMedicoController
    {
        Task<List<MedicoResponseDTO>> BuscarMedicos();
        Task<AgendaResponseDTO> BuscarAgenda();
        Task<AgendaResponseDTO> CadastrarAgenda();
        Task<AgendaResponseDTO> AtualizarAgenda();
        Task DeletarAgenda();
    }
}
