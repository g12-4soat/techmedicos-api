using TechMedicos.Core;

namespace TechMedicos.Domain.Entities
{
    public abstract class Usuario : Entity
    {
        protected Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        protected Usuario(string id, string nome, string senha) : base(id)
        {
            Nome = nome;
            Senha = senha;
        }

        public string Nome { get; protected set; }
        public string Senha { get; protected set; }
    }
}
