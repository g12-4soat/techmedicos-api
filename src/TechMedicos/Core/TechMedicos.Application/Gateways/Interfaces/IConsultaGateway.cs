using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Gateways.Interfaces
{
    public interface IConsultaGateway
    {
        Task<Consulta> Cadastrar(Consulta consulta);
        Task<Consulta> ObterPorId(string consultaId);
        Task<Consulta> Atualizar(Consulta consulta);
    }
}
