using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Ports.Repositories
{
    public interface IPacienteRepository:IRepository<Paciente>
    {
        Task<Paciente> ObterPorId(string pacienteId);
    }
}
