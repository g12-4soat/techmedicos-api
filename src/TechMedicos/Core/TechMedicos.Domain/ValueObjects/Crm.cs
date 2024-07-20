using TechMedicos.Core;

namespace TechMedicos.Domain.ValueObjects
{
    public class Crm : ValueObject
    {
        private Crm() { }

        protected override IEnumerable<object> RetornarPropriedadesDeEquidade()
        {
            throw new NotImplementedException();
        }
    }
}
