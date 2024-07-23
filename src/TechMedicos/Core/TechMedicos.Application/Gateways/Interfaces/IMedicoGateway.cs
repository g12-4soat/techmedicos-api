using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Gateways.Interfaces
{
    public interface IMedicoGateway
    {
        Task<List<Medico>> ObterTodos();
        Task<Medico> ObterPorId(string medicoId);
        Task<Medico> Cadastrar(Medico medico);
        Task<Medico> Atualizar(Medico medico);
    }
}
