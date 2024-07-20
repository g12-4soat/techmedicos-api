using TechMedicos.Core;

namespace TechMedicos.Domain.ValueObjects
{
    public class AgendamentoMedico : ValueObject
    {
        public AgendamentoMedico(string crm, DateOnly data, List<HorarioDisponivel> horarios)
        {
            Crm = new Crm(crm);
            Data = data;
            Horarios = horarios;
        }

        public Crm Crm { get; private set; }
        public DateOnly Data { get; private set; }
        public List<HorarioDisponivel> Horarios { get; private set; }

        protected override IEnumerable<object> RetornarPropriedadesDeEquidade()
        {
            yield return Crm;
            yield return Data;
            yield return Horarios;
        }
    }

    public class HorarioDisponivel : ValueObject
    {
        public HorarioDisponivel(TimeOnly horaInicio)
        {
            HoraInicio = horaInicio;
            HoraFim = horaInicio.AddMinutes(50);
        }

        public TimeOnly HoraInicio { get; private set; }
        public TimeOnly HoraFim { get; private set; }

        protected override IEnumerable<object> RetornarPropriedadesDeEquidade()
        {
            yield return HoraInicio;
            yield return HoraFim;
        }
    }
}
