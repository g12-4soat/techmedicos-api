using Amazon.DynamoDBv2.DataModel;
using TechMedicos.Adapter.DynamoDB.Models.Converter;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.Enums;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Adapter.DynamoDB.Models
{
    [DynamoDBTable("medicos")]
    public class MedicoDbModel
    {
        public MedicoDbModel(IEnumerable<AgendaMedica>? agendamentos, Crm crm, decimal valorConsulta, string nome)
        {
            Id = Guid.NewGuid().ToString();
            Agendamentos = agendamentos.ToList();
            Crm = crm.Documento;
            ValorConsulta = valorConsulta;
            Nome = nome;
        }
        public MedicoDbModel(string medicoId, IEnumerable<AgendaMedica>? agendamentos, Crm crm, decimal valorConsulta, string nome)
        {
            Id = medicoId;
            Agendamentos = agendamentos.ToList();
            Crm = crm.Documento;
            ValorConsulta = valorConsulta;
            Nome = nome;
        }

        public MedicoDbModel()
        {

        }

        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBProperty(Converter = typeof(AgendaConverter))]
        public List<AgendaMedica>? Agendamentos { get; set; }
        public string Crm { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Nome { get; set; }

        public int DistanciaKm { get; set; }
        public decimal Avaliacao { get; set; }
        public EspecialidadeMedica Especialidade { get; set; }

        //public class AgendaMedicaDbModel
        //{
        //    public DateOnly Data { get; set; }
        //    public List<HorarioDisponivel> _horarios { get; set; }
        //}
        //public class HorarioDisponivelDbModel
        //{
        //    public TimeOnly HoraInicio { get; set; }
        //    public TimeOnly HoraFim { get; set; }
        //}
    }
}