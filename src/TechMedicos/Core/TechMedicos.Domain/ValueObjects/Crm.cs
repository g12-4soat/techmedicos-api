using System.Text.RegularExpressions;
using TechMedicos.Core;

namespace TechMedicos.Domain.ValueObjects
{
    public class Crm : ValueObject
    {
        public Crm(string documento)
        {
            ArgumentNullException.ThrowIfNull(documento);

            Documento = Validar(documento) ? LimparCrm(documento) : throw new DomainException($"CRM inválido {documento}");
        }

        public string Documento { get; private set; }

        public static bool Validar(string documento)
        {
            string documentoLimpo = LimparCrm(documento);

            // Verifica se o CRM está no formato correto
            if (!Regex.IsMatch(documentoLimpo, @"^\d{4,10}/[A-Z]{2}$"))
            {
                return false;
            }

            // Verifica se a sigla do estado é válida
            string estado = documentoLimpo.Substring(documentoLimpo.LastIndexOf('/') + 1);
            return ValidarEstado(estado);
        }

        private static bool ValidarEstado(string estado)
        {
            // Lista de siglas de estados brasileiros (pode ser expandida conforme necessário)
            string[] siglas = ["AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"];

            return Array.Exists(siglas, s => s.Equals(estado, StringComparison.OrdinalIgnoreCase));
        }

        private static string LimparCrm(string documento)
        {
            // Remove caracteres não numéricos, exceto a barra e as letras
            return Regex.Replace(documento, @"[^\d/A-Z]", "");
        }

        protected override IEnumerable<object> RetornarPropriedadesDeEquidade()
        {
            yield return Documento;
        }
    }
}
