using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.Enums;

namespace TechMedicos.UnitTests.Domain
{
    [Trait("Domain", "ConsultaTest")]
    public class ConsultaTest
    {
        [Fact]
        public void CriarConsulta_DeveRetornarSucesso()
        {
            // Arrange
            string medicoId = Guid.NewGuid().ToString();
            string pacienteId = Guid.NewGuid().ToString();
            DateTime dataConsulta = DateTime.Now;
            decimal valor = 100;

            // Act
            var consulta = new Consulta(medicoId, pacienteId, dataConsulta, valor);

            // Assert
            Assert.Equal(medicoId, consulta.MedicoId);
            Assert.Equal(pacienteId, consulta.PacienteId);
            Assert.Equal(dataConsulta, consulta.DataConsulta);
            Assert.Equal(valor, consulta.Valor);
            Assert.Equal(StatusConsulta.Agendada, consulta.Status);
        }

        [Fact]
        public void AtualizarConsulta_DeveRetornarSucesso()
        {
            // Arrange
            string id = Guid.NewGuid().ToString();
            string medicoId = Guid.NewGuid().ToString();
            string pacienteId = Guid.NewGuid().ToString();
            DateTime dataConsulta = DateTime.Now;
            decimal valor = 100;
            StatusConsulta status = StatusConsulta.Realizada;

            // Act
            var consulta = new Consulta(id, medicoId, pacienteId, dataConsulta, valor, status);

            // Assert
            Assert.Equal(id, consulta.Id);
            Assert.Equal(medicoId, consulta.MedicoId);
            Assert.Equal(pacienteId, consulta.PacienteId);
            Assert.Equal(dataConsulta, consulta.DataConsulta);
            Assert.Equal(valor, consulta.Valor);
            Assert.Equal(status, consulta.Status);
        }
    }
}
