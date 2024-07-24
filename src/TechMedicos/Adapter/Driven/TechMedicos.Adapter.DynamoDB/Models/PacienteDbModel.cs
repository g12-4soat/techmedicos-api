using Amazon.DynamoDBv2.DataModel;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Adapter.DynamoDB.Models
{
    [DynamoDBTable("pacientes")]
    public class PacienteDbModel
    {
        public PacienteDbModel(Cpf cpf, Email email, string nome)
        {
            Id = Guid.NewGuid().ToString();
            Cpf = cpf.Numero;
            Email = email.EnderecoEmail;
            Nome = nome;
        }
        public PacienteDbModel()
        {
                
        }

        [DynamoDBHashKey]
        public string Id { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}