using TechMedicos.Core;
using TechMedicos.Domain.Enums;

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
            ArgumentException.ThrowIfNullOrWhiteSpace(MedicoId);
            ArgumentException.ThrowIfNullOrWhiteSpace(PacienteId);
        }

        public void Aceitar()
        {
            if (Status != StatusConsulta.Agendada)
                throw new DomainException("Para confirmar a consulta ela deve estar agendada.");

            Status = StatusConsulta.Confirmada;
        }

        public void Recusar(string? justificativa = "Necessário reagendamento")
        {
            if (Status != StatusConsulta.Agendada)
                throw new DomainException("Para recusar a consulta ela deve estar agendada.");

            Justificativa = justificativa;
            Status = StatusConsulta.Rejeitada;
        }

        public void Realizar()
        {
            if (Status != StatusConsulta.Confirmada)
                throw new DomainException("Para realizar a consulta ela deve estar confirmada.");

            Status = StatusConsulta.Realizada;
        }

        public void Cancelar(string justificativa)
        {
            if (Status == StatusConsulta.Rejeitada)
                throw new DomainException("A consulta não pode ser cancelada pois o médico não aceitou a consulta.");

            if (Status == StatusConsulta.Realizada)
                throw new DomainException("A consulta não pode ser cancelada pois ela já foi realizada.");

            if (justificativa.Length < 3 || justificativa.Length > 500)
                throw new DomainException("Justificativa precisa ter entre 3 e 500 caracteres");

            Justificativa = justificativa;
            Status = StatusConsulta.Cancelada;
        }

        public void SetMedico(Medico medico)
        {
            this.Medico = medico;
        }

        public void SetPaciente(Paciente paciente)
        {
            this.Paciente = paciente;
        }

        public void SetJustificativa(string? justificativa)
        {
            this.Justificativa = justificativa;
        }
    }
}
