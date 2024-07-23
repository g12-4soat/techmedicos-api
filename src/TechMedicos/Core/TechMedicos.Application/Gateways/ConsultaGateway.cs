using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Gateways
{
    public class ConsultaGateway : IConsultaGateway
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaGateway(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public Task<Consulta> Atualizar(Consulta consulta)
        {
            return _consultaRepository.Atualizar(consulta);
        }

        public Task<Consulta> Cadastrar(Consulta consulta)
        {
            return _consultaRepository.Cadastrar(consulta);
        }

        public Task<Consulta> ObterPorId(string consultaId)
        {
            return _consultaRepository.ObterPorId(consultaId);
        }
    }
}