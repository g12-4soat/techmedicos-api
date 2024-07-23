using TechMedicos.Application.DTOs;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.Controllers.Interfaces
{
    public interface IConsultaController
    {
        Task<ConsultaResponseDTO> CadastrarConsulta(int medicoId, int pacienteId, DateTime dataConsulta, decimal valor);
        Task<ConsultaResponseDTO> AtualizarConsulta(int consultaId, StatusConsulta statusConsulta, string justificativa);
        Task<ConsultaResponseDTO> BuscarConsultaPorId(int consultaId);
        Task<List<ConsultaResponseDTO>> BuscarConsultas();
    }
}
