using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Gateways
{
    public class MedicoGateway : IMedicoGateway
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoGateway(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public Task<Medico> Atualizar(Medico medico)
        {
            return _medicoRepository.Atualizar(medico);
        }

        public Task<Medico> Cadastrar(Medico medico)
        {
            return _medicoRepository.Cadastrar(medico);
        }

        public Task<Medico> ObterPorId(string medicoId)
        {
            return _medicoRepository.ObterPorId(medicoId);
        }

        public Task<List<Medico>> ObterTodos()
        {
            return _medicoRepository.ObterTodos();
        }
    }
}