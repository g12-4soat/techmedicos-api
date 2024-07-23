using TechMedicos.Core;
using TechMedicos.Domain.Entities;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Domain.Aggregates
{
    public class Medico : Usuario, IAggregateRoot
    {
        public Medico(string nome, string crm, decimal valorConsulta)
            : base(nome)
        {
            Crm = new Crm(crm);
            ValorConsulta = valorConsulta;
            _agendamentos = new List<AgendamentoMedico>();
            Validar();
        }

        public Medico(string id, string nome, string crm, decimal valorConsulta, List<AgendamentoMedico> agendamentos)
            : base(id, nome)
        {
            Crm = new Crm(crm);
            ValorConsulta = valorConsulta;
            _agendamentos = new List<AgendamentoMedico>();
            AdicionarAgendamentos(agendamentos);
            Validar();
        }

        private readonly List<AgendamentoMedico> _agendamentos;
        public IReadOnlyCollection<AgendamentoMedico> Agendamentos => _agendamentos;
        public Crm Crm { get; private set; }
        public decimal ValorConsulta { get; private set; }
        public IReadOnlyCollection<Consulta> Consultas { get; private set; } = default!;

        public void AdicionarAgendamentos(List<AgendamentoMedico> agendamentos)
        {
            foreach (var agendamento in agendamentos)
                AdicionarAgendamento(agendamento);
        }

        public void AdicionarAgendamento(AgendamentoMedico agendamentoMedico)
        {
            if (_agendamentos.Any(x => x.Data == agendamentoMedico.Data))
                throw new DomainException("Já possui uma agenda configurada para essa data selecionada");

            _agendamentos.Add(agendamentoMedico);
        }

        private void Validar()
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(Nome);
            ArgumentNullException.ThrowIfNull(Crm);
            ArgumentNullException.ThrowIfNull(ValorConsulta);

            if (Nome.Length <= 1 || Nome.Length > 100)
                throw new DomainException("Nome precisa ter entre 2 e 100 caracteres");
        }
    }
}
