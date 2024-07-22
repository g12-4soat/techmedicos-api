using TechMedicos.Core;

namespace TechMedicos.Domain.Entities
{
    public abstract class Usuario : Entity
    {
        protected Usuario(string nome)
        {
            Nome = nome;
        }

        protected Usuario(string id, string nome) : base(id)
        {
            Nome = nome;
        }

        public string Nome { get; protected set; }
    }
}
