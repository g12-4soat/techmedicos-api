using TechMedicos.Core;

namespace TechMedicos.Domain.Aggregates
{
    public abstract class Usuario : Entity, IAggregateRoot
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
