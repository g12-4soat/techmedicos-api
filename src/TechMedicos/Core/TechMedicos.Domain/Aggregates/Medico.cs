using TechMedicos.Core;
using TechMedicos.Domain.Entities;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Domain.Aggregates
{
    public class Medico : Usuario, IAggregateRoot
    {
        public Medico(string nome, string senha, string crm, decimal valorConsulta)
            : base(nome, senha)
        {
            Crm = new Crm(crm);
            ValorConsulta = valorConsulta;
        }

        public Medico(string id, string nome, string senha, string crm, decimal valorConsulta)
            : base(id, nome, senha)
        {
            Crm = new Crm(crm);
            ValorConsulta = valorConsulta;
        }

        public Crm Crm { get; private set; }
        public decimal ValorConsulta { get; private set; }
    }
}
