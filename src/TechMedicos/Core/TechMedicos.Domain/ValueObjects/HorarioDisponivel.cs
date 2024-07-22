using TechMedicos.Core;

namespace TechMedicos.Domain.ValueObjects
{
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
