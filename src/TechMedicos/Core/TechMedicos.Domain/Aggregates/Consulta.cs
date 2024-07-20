using TechMedicos.Core;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Domain.Aggregates
{
    public class Consulta : Entity, IAggregateRoot
    {
        public DateTime DataConsulta { get; private set; }
        public StatusConsulta Status { get; private set; }
        public decimal Valor { get; private set; }
        public string? Justificativa { get; private set; }

        public void Aceitar()
        {
            Status = StatusConsulta.Confirmada;
        }

        public void Recusar(string? justificativa)
        {
            Justificativa = justificativa;
            Status = StatusConsulta.Rejeitada;
        }

        public void Cancelar(string justificativa)
        {
            //TODO: Criar validações
            Justificativa = justificativa;
            Status = StatusConsulta.Cancelada;
        }
    }
}
