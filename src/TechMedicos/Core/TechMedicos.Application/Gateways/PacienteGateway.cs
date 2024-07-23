using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.Gateways
{
    public class PacienteGateway : IPacienteGateway
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteGateway(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public Task<Paciente> ObterPorId(string pacienteId)
        {
            return _pacienteRepository.ObterPorId(pacienteId);
        }
    }
}