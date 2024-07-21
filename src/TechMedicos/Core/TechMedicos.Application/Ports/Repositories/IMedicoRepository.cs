using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Ports.Repositories
{
    public interface IMedicoRepository:IRepository<Medico>
    {
        Task<List<Medico>> ObterTodos();
        Task<Medico> ObterPorId(string medicoId);
        Task<Medico> Cadastrar(Medico medico);
        Task<Medico> Atualizar(Medico medico);
        Task Deletar(string medicoId);
    }
}