using Amazon.DynamoDBv2.DataModel;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Adapter.DynamoDB.Models
{
    public class ConsultaDbModel
    {
        public ConsultaDbModel(string medicoId, MedicoDbModel medico, string pacienteId,
            PacienteDbModel paciente, DateTime dataConsulta, StatusConsulta status,
            decimal valor, string? justificativa)
        {
            Id = Guid.NewGuid().ToString();
            MedicoId = medicoId;
            Medico = medico;
            PacienteId = pacienteId;
            Paciente = paciente;
            DataConsulta = dataConsulta;
            Status = status;
            Valor = valor;
            Justificativa = justificativa;
        }

        [DynamoDBHashKey]
        public string Id { get; set; }
        public string MedicoId { get; set; }
        public MedicoDbModel Medico { get; set; }
        public string PacienteId { get; set; }
        public PacienteDbModel Paciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public StatusConsulta Status { get; set; }
        public decimal Valor { get; set; }
        public string? Justificativa { get; set; }
    }
}