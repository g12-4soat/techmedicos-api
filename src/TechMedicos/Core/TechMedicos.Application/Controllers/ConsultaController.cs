using Mapster;
using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.DTOs;
using TechMedicos.Application.Gateways;
using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Application.UseCases.Consultas;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.Controllers
{
    public class ConsultaController : IConsultaController
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IConsultaGateway _consultaGateway;
        private readonly IMedicoGateway _medicoGateway;
        private readonly IPacienteGateway _pacienteGateway;

        public ConsultaController(IConsultaRepository consultaRepository, IConsultaGateway consultaGateway)
        {
            _consultaRepository = consultaRepository;
            _consultaGateway = new ConsultaGateway(_consultaRepository);
        }

        public async Task<ConsultaResponseDTO> AtualizarConsulta(string consultaId, StatusConsulta statusConsulta, string justificativa)
        {
            var consulta = await ConsultaUseCases.Atualizar(consultaId, statusConsulta, justificativa, _consultaGateway);
            return consulta.Adapt<ConsultaResponseDTO>();
        }

        public async Task<ConsultaResponseDTO> BuscarConsultaPorId(string consultaId)
        {
            var consulta = await _consultaGateway.ObterPorId(consultaId);
            return consulta.Adapt<ConsultaResponseDTO>();
        }

        public Task<List<ConsultaResponseDTO>> BuscarConsultas()
        {
            //criar no repository e na gateway o método de buscar todas as consultas sem filtro algum.
            throw new NotImplementedException();
        }

        public async Task<ConsultaResponseDTO> CadastrarConsulta(string medicoId, string pacienteId, DateTime dataConsulta)
        {
            var consulta = await ConsultaUseCases.Cadastrar(medicoId, pacienteId, dataConsulta, _consultaGateway, _medicoGateway, _pacienteGateway);
            return consulta.Adapt<ConsultaResponseDTO>();
        }
    }
}
