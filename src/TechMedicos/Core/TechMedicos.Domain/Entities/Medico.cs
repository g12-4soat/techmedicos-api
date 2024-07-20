using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Domain.Entities
{
    public class Medico : Usuario
    {
        public Medico(string nome, string senha, string crm) 
            : base(nome, senha)
        {
            Crm = new Crm(crm);
        }

        public Medico(string id, string nome, string senha, string crm) 
            : base(id, nome, senha)
        {
            Crm = new Crm(crm);
        }

        public Crm Crm { get; private set; }
    }
}
