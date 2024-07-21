using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Ports.Repositories
{
    public interface IConsultaRepository:IRepository<Consulta>
    {
        Task<Consulta> Cadastrar(Consulta consulta);
        Task<Consulta> ObterPorId(string consultaId);
        Task<Consulta> Atualizar(Consulta consulta);
    }
}