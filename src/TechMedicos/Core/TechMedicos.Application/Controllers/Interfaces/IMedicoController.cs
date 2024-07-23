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
        Task<AgendaMedicaResponseDTO> BuscarAgenda(string medicoId);
        Task<AgendaMedicaResponseDTO> CadastrarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios);
        Task<AgendaMedicaResponseDTO> AtualizarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios);
        Task DeletarAgenda(string medicoId, DateOnly data);
    }
}
