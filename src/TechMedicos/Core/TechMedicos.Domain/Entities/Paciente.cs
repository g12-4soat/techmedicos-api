using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Domain.Entities
{
    public class Paciente : Usuario
    {
        public Paciente(string nome, string senha, string cpf, string email)
            : base(nome, senha)
        {
            Cpf = new Cpf(cpf);
            Email = new Email(email);
        }

        public Paciente(string id, string nome, string senha, string cpf, string email)
            : base(id, nome, senha)
        {
            Cpf = new Cpf(cpf);
            Email = new Email(email);
        }

        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
    }
}