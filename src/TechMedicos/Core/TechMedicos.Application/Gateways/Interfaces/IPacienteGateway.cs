using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Gateways.Interfaces
{
    public interface IPacienteGateway
    {
        Task<Paciente> ObterPorId(string pacienteId);
    }
}
