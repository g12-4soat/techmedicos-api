using TechMedicos.Application.DTOs;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.Controllers.Interfaces
{
    public interface IConsultaController
    {
        Task<ConsultaResponseDTO> CadastrarConsulta(string medicoId, string pacienteId, DateTime dataConsulta, decimal valor);
        Task<ConsultaResponseDTO> AtualizarConsulta(string consultaId, StatusConsulta statusConsulta, string justificativa);
        Task<ConsultaResponseDTO> BuscarConsultaPorId(string consultaId);
        Task<List<ConsultaResponseDTO>> BuscarConsultas();
    }
}
