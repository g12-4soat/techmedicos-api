using TechMedicos.Application.DTOs;

namespace TechMedicos.Application.Controllers.Interfaces
{
    public interface IConsultaController
    {
        Task<ConsultaResponseDTO> CadastrarConsulta();
        Task<ConsultaResponseDTO> AtualizarConsulta();
        Task<ConsultaResponseDTO> BuscarConsultaPorId();
        Task<List<ConsultaResponseDTO>> BuscarConsultas();
    }
}
