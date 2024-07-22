using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.DTOs;

namespace TechMedicos.Application.Controllers
{
    public class ConsultaController : IConsultaController
    {
        public Task<ConsultaResponseDTO> AtualizarConsulta(int consultaId, int medicoId, int pacienteId, DateTime dataConsulta, decimal valor)
        {
            throw new NotImplementedException();
        }

        public Task<ConsultaResponseDTO> BuscarConsultaPorId(int consultaId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ConsultaResponseDTO>> BuscarConsultas()
        {
            throw new NotImplementedException();
        }

        public Task<ConsultaResponseDTO> CadastrarConsulta(int medicoId, int pacienteId, DateTime dataConsulta, decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
