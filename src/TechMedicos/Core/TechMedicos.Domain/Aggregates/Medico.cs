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
            _agendamentos = new List<AgendaMedica>();
            Validar();
        }

        public Medico(string id, string nome, string crm, decimal valorConsulta, List<AgendaMedica> agendamentos)
            : base(id, nome)
        {
            Crm = new Crm(crm);
            ValorConsulta = valorConsulta;
            _agendamentos = new List<AgendaMedica>();
            AdicionarAgendamentos(agendamentos);
            Validar();
        }

        private readonly List<AgendaMedica> _agendamentos;
        public IReadOnlyCollection<AgendaMedica> Agendamentos => _agendamentos;
        public Crm Crm { get; private set; }
        public decimal ValorConsulta { get; private set; }
        public IReadOnlyCollection<Consulta> Consultas { get; private set; } = default!;

        public void AdicionarAgendamentos(List<AgendaMedica> agendamentos)
        {
            foreach (var agendamento in agendamentos)
                AdicionarAgendamento(agendamento);
        }

        public void AdicionarAgendamento(AgendaMedica agendamentoMedico)
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
