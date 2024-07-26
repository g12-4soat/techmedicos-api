using TechMedicos.Application.DTOs;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.Controllers.Interfaces
{
    public interface IMedicoController
    {
        Task<List<MedicoResponseDTO>> BuscarMedicos(EspecialidadeMedica? especialidade, int? distanciaKm, decimal? avaliacao);
        Task<List<AgendaMedicaResponseDTO>> BuscarAgenda(string medicoId);
        Task<List<AgendaMedicaResponseDTO>> CadastrarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios);
        Task<List<AgendaMedicaResponseDTO>> AtualizarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios);
        Task DeletarAgenda(string medicoId, DateOnly data);
    }
}
