using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.DTOs;
using TechMedicos.Application.Gateways;
using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.Controllers
{
    public class ConsultaController : IConsultaController
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IConsultaGateway _consultaGateway;

        public ConsultaController(IConsultaRepository consultaRepository, IConsultaGateway consultaGateway)
        {
            _consultaRepository = consultaRepository;
            _consultaGateway = new ConsultaGateway(_consultaRepository);
        }

        public Task<ConsultaResponseDTO> AtualizarConsulta(string consultaId, StatusConsulta statusConsulta, string justificativa)
        {
            //usecase pra saber se a consulta existe e atualizar
            //medico aceita e rejeita
            //paciente aceita e cancela
            //justificativa do médico = padrão
            //justificativa do paciente = variável
            throw new NotImplementedException();
        }

        public async Task<ConsultaResponseDTO> BuscarConsultaPorId(string consultaId)
        {
           return await _consultaGateway.ObterPorId(consultaId);
        }

        public Task<List<ConsultaResponseDTO>> BuscarConsultas()
        {
            //criar no repository e na gateway o método de buscar todas as consultas sem filtro algum.
            throw new NotImplementedException();
        }

        public Task<ConsultaResponseDTO> CadastrarConsulta(string medicoId, string pacienteId, DateTime dataConsulta, decimal valor)
        {
            //Validar se existe uma consulta com esse medico e paciente na data informada
            //usar o buscarConsultas para retornar tudo e filtrar para aquele médico/paciente
            //consultar e validar se o médico existe
            //consultar e validar se o paciente existe
            //Validar horário da agenda médica com a data informada para saber se está disponivel
            //remover o decimal do valor, pq é estabelicido na domain do médico
            throw new NotImplementedException();
        }
    }
}
