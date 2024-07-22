using Amazon.DynamoDBv2.DataModel;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Adapter.DynamoDB.Models
{
    [DynamoDBTable("medicos")]
    public class MedicoDbModel
    {
        public MedicoDbModel(IEnumerable<AgendamentoMedico>? agendamentos, Crm crm, decimal valorConsulta, string nome)
        {
            Id = Guid.NewGuid().ToString();
            Agendamentos = agendamentos;
            Crm = crm.Documento;
            ValorConsulta = valorConsulta;
            Nome = nome;
        }

        [DynamoDBHashKey]
        public string Id { get; set; }
        public IEnumerable<AgendamentoMedico>? Agendamentos { get; set; }
        public string Crm { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Nome { get; set; }
    }
}