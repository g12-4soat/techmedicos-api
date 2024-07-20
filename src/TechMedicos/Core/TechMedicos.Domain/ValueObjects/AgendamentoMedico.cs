using TechMedicos.Core;

namespace TechMedicos.Domain.ValueObjects
{
    public class AgendamentoMedico : ValueObject
    {
        private AgendamentoMedico()
        {

        }

        protected override IEnumerable<object> RetornarPropriedadesDeEquidade()
        {
            throw new NotImplementedException();
        }
    }
}
