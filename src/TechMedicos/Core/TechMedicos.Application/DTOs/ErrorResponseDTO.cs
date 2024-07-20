using System.Net;

namespace TechMedicos.Application.DTOs
{
    public class ErrorResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public string MensagemErro { get; set; }
    }
}
