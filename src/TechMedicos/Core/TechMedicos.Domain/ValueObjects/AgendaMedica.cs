using TechMedicos.Core;

namespace TechMedicos.Domain.ValueObjects
{
    public class AgendaMedica : ValueObject
    {
        public AgendaMedica(DateOnly data, List<HorarioDisponivel> horarios)
        {
            Data = data;
            _horarios = new List<HorarioDisponivel>();
            AdicionarHorarios(horarios);
            Validar();
        }

        private readonly List<HorarioDisponivel> _horarios;
        public IReadOnlyCollection<HorarioDisponivel> Horarios => _horarios;
        public DateOnly Data { get; private set; }

        public void AdicionarHorarios(List<HorarioDisponivel> horarios)
        {
            foreach (var horario in horarios.OrderBy(x => x.HoraInicio))
                AdicionarHorario(horario);
        }

        public void AdicionarHorario(HorarioDisponivel horarioDisponivel)
        {
            if (_horarios.Any(x => x.HoraInicio <= horarioDisponivel.HoraInicio && x.HoraFim >= horarioDisponivel.HoraInicio))
                throw new DomainException("O horário selecionado já está configurado. Por favor, verifique novamente a agenda do médico e tente novamente.");
            _horarios.Add(horarioDisponivel);
        }

        private void Validar()
        {
            ArgumentNullException.ThrowIfNull(Data);
            ArgumentNullException.ThrowIfNull(Horarios);

            if (Horarios.Count == 0)
                throw new DomainException("Deve possuir horário disponível na agenda do médico");
        }

        protected override IEnumerable<object> RetornarPropriedadesDeEquidade()
        {
            yield return Data;
            yield return Horarios;
        }
    }
}
