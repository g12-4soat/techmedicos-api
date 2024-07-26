namespace TechMedicos.Application.DTOs
{
    public class MedicoResponseDTO
    {
        public string Id { get; set; }
        public List<AgendaMedicaResponseDTO>? Agendas { get; set; }
        public string Crm { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Nome { get; set; }
        public int DistanciaKm { get; set; }
        public decimal Avaliacao { get; set; }
        public string Especialidade { get; set; }
    }
}
