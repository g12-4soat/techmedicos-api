using TechMedicos.Core;
using TechMedicos.Domain.Entities;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Domain.Aggregates
{
    public class Paciente : Usuario, IAggregateRoot
    {
        public Paciente(string nome, string cpf, string email)
            : base(nome)
        {
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            Validar();
        }

        public Paciente(string id, string nome, string cpf, string email)
            : base(id, nome)
        {
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            Validar();
        }

        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public IReadOnlyCollection<Consulta> Consultas { get; private set; } = default!;

        private void Validar()
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(Nome);
            ArgumentNullException.ThrowIfNull(Cpf);
            ArgumentNullException.ThrowIfNull(Email);

            if (Nome.Length <= 1 || Nome.Length > 100)
                throw new DomainException("Nome precisa ter entre 2 e 100 caracteres");
        }
    }
}