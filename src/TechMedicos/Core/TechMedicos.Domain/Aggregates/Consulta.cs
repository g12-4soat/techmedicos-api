using TechMedicos.Core;
using TechMedicos.Domain.Enums;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Domain.Aggregates
{
    public class Consulta : Entity, IAggregateRoot
    {
        public Consulta(string medicoId, string pacienteId, DateTime dataConsulta, decimal valor)
        {
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataConsulta = dataConsulta;
            Valor = valor;
            Status = StatusConsulta.Agendada;
            Validar();
        }

        public Consulta(
            string id, 
            string medicoId, 
            string pacienteId, 
            DateTime dataConsulta, 
            decimal valor, 
            StatusConsulta status)
            : base(id)
        {
            MedicoId = medicoId;
            PacienteId = pacienteId;
            DataConsulta = dataConsulta;
            Valor = valor;
            Status = status;
            Validar();
        }

        public string MedicoId { get; private set; }
        public Medico Medico { get; private set; } = default!;
        public string PacienteId { get; private set; }
        public Paciente Paciente { get; private set; } = default!;
        public DateTime DataConsulta { get; private set; }
        public StatusConsulta Status { get; private set; }
        public decimal Valor { get; private set; }
        public string? Justificativa { get; private set; }

        private void Validar()
        {
            ArgumentNullException.ThrowIfNull(DataConsulta);
            ArgumentNullException.ThrowIfNull(Status);
            ArgumentNullException.ThrowIfNull(Valor);
            ArgumentException.ThrowIfNullOrEmpty(MedicoId);
            ArgumentException.ThrowIfNullOrEmpty(PacienteId);
        }

        public void Aceitar()
        {
            Status = StatusConsulta.Confirmada;
        }

        public void Recusar(string? justificativa)
        {
            Justificativa = justificativa;
            Status = StatusConsulta.Rejeitada;
        }

        public void Cancelar(string justificativa)
        {
            ArgumentException.ThrowIfNullOrEmpty(justificativa);
            ArgumentException.ThrowIfNullOrWhiteSpace(justificativa);

            if (justificativa.Length < 3 && justificativa.Length > 500)
                throw new DomainException("Justificativa precisa ter entre 3 e 500 caracteres");

            Justificativa = justificativa;
            Status = StatusConsulta.Cancelada;
        }
    }
}
