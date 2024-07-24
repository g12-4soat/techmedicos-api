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
        public IReadOnlyCollection<AgendaMedica> Agendas => _agendas;
        public Crm Crm { get; private set; }
        public decimal ValorConsulta { get; private set; }
        public IReadOnlyCollection<Consulta> Consultas { get; private set; } = default!;


        public void AdicionarAgendamento(AgendaMedica agenda)
        {
            if (ValidarAgendamentoExistente(agenda.Data))
                throw new DomainException("Já possui uma agenda configurada para essa data selecionada.");

            _agendas.Add(agenda);
        }

        public void AtualizarAgendamento(AgendaMedica agenda)
        {
            if (ValidarAgendamentoExistente(agenda.Data))
            {
                DeletarAgenda(agenda.Data);
                AdicionarAgendamento(agenda);
            }
            else
            {
                throw new DomainException("Não existe nenhum agenda para a data selecionada.");
            }
        }

        public void DeletarAgendamento(DateOnly data)
        {
            if (ValidarAgendamentoExistente(data))
            {
                DeletarAgenda(data);
            }
            else
            {
                throw new DomainException("Não existe nenhum agenda para a data selecionada.");
            }
        }

        private void DeletarAgenda(DateOnly data)
        {
            _agendas.RemoveAll(x => x.Data == data);
        }

        private bool ValidarAgendamentoExistente(DateOnly data)
        {
            return _agendas.Any(x => x.Data == data);
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
