using TechMedicos.Core;
using TechMedicos.Domain.Entities;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Domain.Aggregates
{
    public class Paciente : Usuario, IAggregateRoot
    {
        public Paciente(string nome, string senha, string cpf, string email)
            : base(nome, senha)
        {
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            Validar();
        }

        public Paciente(string id, string nome, string senha, string cpf, string email)
            : base(id, nome, senha)
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
            ArgumentException.ThrowIfNullOrEmpty(Nome);
            ArgumentException.ThrowIfNullOrEmpty(Senha);
            ArgumentException.ThrowIfNullOrWhiteSpace(Nome);
            ArgumentException.ThrowIfNullOrWhiteSpace(Senha);
            ArgumentNullException.ThrowIfNull(Cpf);
            ArgumentNullException.ThrowIfNull(Email);

            if (Nome.Length <= 1 || Nome.Length > 100)
                throw new DomainException("Nome precisa ter entre 2 e 100 caracteres");
        }
    }
}