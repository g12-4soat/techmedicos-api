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
            _agendas = new List<AgendaMedica>();
            Validar();
        }

        public Medico(string id, string nome, string crm, decimal valorConsulta, List<AgendaMedica> agendas)
            : base(id, nome)
        {
            Crm = new Crm(crm);
            ValorConsulta = valorConsulta;
            _agendas = agendas;
            Validar();
        }

        private readonly List<AgendaMedica> _agendas;
        public IReadOnlyCollection<AgendaMedica> agendas => _agendas;
        public Crm Crm { get; private set; }
        public decimal ValorConsulta { get; private set; }
        public IReadOnlyCollection<Consulta> Consultas { get; private set; } = default!;


        public void AdicionarAgendamento(AgendaMedica agenda)
        {
            if (ValidarAgendamentoExistente(agenda))
                throw new DomainException("Já possui uma agenda configurada para essa data selecionada.");

            _agendas.Add(agenda);
        }

        public void AtualizarAgendamento(AgendaMedica agenda)
        {
            if (ValidarAgendamentoExistente(agenda))
            {
                DeletarAgenda(agenda);
                AdicionarAgendamento(agenda);
            }
            else
            {
                throw new DomainException("Não existe nenhum agenda para a data selecionada.");
            }
        }

        public void DeletarAgendamento(AgendaMedica agenda)
        {
            if (ValidarAgendamentoExistente(agenda))
            {
                DeletarAgenda(agenda);
            }
            else
            {
                throw new DomainException("Não existe nenhum agenda para a data selecionada.");
            }
        }

        private void DeletarAgenda(AgendaMedica agenda)
        {
            _agendas.RemoveAll(x => x.Data == agenda.Data);
        }

        private bool ValidarAgendamentoExistente(AgendaMedica agenda)
        {
            return _agendas.Any(x => x.Data == agenda.Data);
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
