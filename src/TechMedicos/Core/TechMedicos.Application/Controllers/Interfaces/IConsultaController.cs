using TechMedicos.Application.DTOs;

namespace TechMedicos.Application.Controllers.Interfaces
{
    public interface IConsultaController
    {
        Task<ConsultaResponseDTO> CadastrarConsulta(int medicoId, int pacienteId, DateTime dataConsulta, decimal valor);
        Task<ConsultaResponseDTO> AtualizarConsulta(int consultaId, int medicoId, int pacienteId, DateTime dataConsulta, decimal valor);
        Task<ConsultaResponseDTO> BuscarConsultaPorId(int consultaId);
        Task<List<ConsultaResponseDTO>> BuscarConsultas();
    }
}
