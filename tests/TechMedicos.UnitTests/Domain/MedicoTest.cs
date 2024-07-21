using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.UnitTests.Domain
{
    [Trait("Domain", "MedicoTest")]
    public class MedicoTest
    {
        [Fact]
        public void CriarMedico_DeveRetornarSucesso()
        {
            // Arrange
            string nome = "Medico Teste";
            string senha = "123456";
            string crm = "0000/SP";
            decimal valorConsulta = 100;

            // Act
            var medico = new Medico(nome, senha, crm, valorConsulta, new List<AgendamentoMedico>());

            // Assert
            Assert.Equal(nome, medico.Nome);
            Assert.Equal(senha, medico.Senha);
            Assert.Equal(crm, medico.Crm.Documento);
            Assert.Equal(valorConsulta, medico.ValorConsulta);
        }

        [Theory]
        [InlineData("", "123456", "0000/SP", 100)]
        [InlineData("Medico Teste 2", "", "0000/SP", 100)]
        [InlineData("Medico Teste 2", "", "0000/SP", null)]
        public void CriarMedico_Invalido_DeveLancarArgumentException(string nome, string senha, string crm, decimal valorConsulta)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Medico(nome, senha, crm, valorConsulta, new List<AgendamentoMedico>()));
        }

        [Fact]
        public void CriarMedico_Invalido_DeveLancarDomainException()
        {
            // Arrange
            string nome = "a";
            string senha = "123456";
            string crm = "0000/SP";
            decimal valorConsulta = 100;

            // Act & Assert
            Assert.Throws<DomainException>(() => new Medico(nome, senha, crm, valorConsulta, new List<AgendamentoMedico>()));
        }

        [Theory]
        [InlineData("0000/OS")]
        [InlineData("000/SP")]
        [InlineData("/SP")]
        [InlineData("00000000000/SP")]
        [InlineData("00000000000")]
        [InlineData("000000-SP")]
        public void CriarMedico_CrmInvalido_DeveLancarException(string crm)
        {
            // Arrange, Act & Assert
            Assert.Throws<DomainException>(() => new Medico("Medico Teste 2", "123456", crm, 100, new List<AgendamentoMedico>()));
        }

        [Fact]
        public void AtualizarMedico_DeveRetornarSucesso()
        {
            // Arrange
            string id = Guid.NewGuid().ToString();
            string nome = "Medico Teste";
            string senha = "123456";
            string crm = "0000/SP";
            decimal valorConsulta = 100;

            // Act
            var medico = new Medico(id, nome, senha, crm, valorConsulta, new List<AgendamentoMedico>());

            // Assert
            Assert.Equal(id, medico.Id);
            Assert.Equal(nome, medico.Nome);
            Assert.Equal(senha, medico.Senha);
            Assert.Equal(crm, medico.Crm.Documento);
            Assert.Equal(valorConsulta, medico.ValorConsulta);
        }

        [Fact]
        public void AdicionarAgendamentos_DeveRetornarSucesso()
        {
            // Arrange
            string nome = "Medico Teste";
            string senha = "123456";
            string crm = "0000/SP";
            decimal valorConsulta = 100;
            DateOnly dataAgendamento = new DateOnly(2024, 07, 21);
            var medico = new Medico(nome, senha, crm, valorConsulta, new List<AgendamentoMedico>());
            var agendamentos = new List<AgendamentoMedico>
            {
                new AgendamentoMedico(crm, dataAgendamento, new List<HorarioDisponivel> 
                { 
                    new HorarioDisponivel(new TimeOnly(8, 30))
                })
            };

            // Act
            medico.AdicionarAgendamentos(agendamentos);

            // Assert
            Assert.Equal(agendamentos.First().Crm.Documento, medico.Agendamentos.First().Crm.Documento);
            Assert.Equal(agendamentos.First().Data, medico.Agendamentos.First().Data);
            Assert.Equal(agendamentos.First().Horarios.First().HoraInicio, medico.Agendamentos.First().Horarios.First().HoraInicio);
            Assert.Equal(agendamentos.First().Horarios.First().HoraInicio.AddMinutes(50), medico.Agendamentos.First().Horarios.First().HoraFim);
        }

        [Fact]
        public void AdicionarAgendamento_DataJaExistente_DeveLancarException()
        {
            // Arrange
            string nome = "Medico Teste";
            string senha = "123456";
            string crm = "0000/SP";
            decimal valorConsulta = 100;
            DateOnly dataAgendamento = new DateOnly(2024, 07, 21);
            var medico = new Medico(nome, senha, crm, valorConsulta, new List<AgendamentoMedico>());
            var agendamentos = new List<AgendamentoMedico>
            {
                new AgendamentoMedico(crm, dataAgendamento, new List<HorarioDisponivel>
                {
                    new HorarioDisponivel(new TimeOnly(8, 30))
                })
            };
            medico.AdicionarAgendamentos(agendamentos);

            // Act & Assert
            Assert.Throws<DomainException>(() => medico.AdicionarAgendamento(agendamentos.First()));
        }

        [Theory]
        [InlineData("00", null)]
        [InlineData("0000/SP", null)]
        public void CriarAgendamentoMedico_Invalido_DeveLancarException(string crm, DateOnly data)
        {
            // Act & Assert
            Assert.Throws<DomainException>(() => new AgendamentoMedico(crm, data, new List<HorarioDisponivel>()));
        }

        [Fact]
        public void AdicionarHorarios_HorarioJaConfigurado_DeveLancarException()
        {
            // Arrange
            string nome = "Medico Teste";
            string senha = "123456";
            string crm = "0000/SP";
            decimal valorConsulta = 100;
            DateOnly dataAgendamento = new DateOnly(2024, 07, 21);
            var medico = new Medico(nome, senha, crm, valorConsulta, new List<AgendamentoMedico>());
            var horariosDisponiveis = new List<HorarioDisponivel>
            {
                new HorarioDisponivel(new TimeOnly(9, 00)),
                new HorarioDisponivel(new TimeOnly(8, 30)),
            };

            // Arrange, Assert & Act
            Assert.Throws<DomainException>(() => new AgendamentoMedico(crm, dataAgendamento, horariosDisponiveis));
        }

        [Fact]
        public void AdicionarHorario_HorarioJaConfigurado_DeveLancarException()
        {
            // Arrange
            string nome = "Medico Teste";
            string senha = "123456";
            string crm = "0000/SP";
            decimal valorConsulta = 100;
            DateOnly dataAgendamento = new DateOnly(2024, 07, 21);
            var medico = new Medico(nome, senha, crm, valorConsulta, new List<AgendamentoMedico>());
            var horariosDisponiveis = new List<HorarioDisponivel>
            {
                new HorarioDisponivel(new TimeOnly(9, 30)),
                new HorarioDisponivel(new TimeOnly(8, 30)),
            };

            // Arrange, Assert & Act
            Assert.Throws<DomainException>(() => 
                new AgendamentoMedico(crm, dataAgendamento, horariosDisponiveis)
                .AdicionarHorario(new HorarioDisponivel(new TimeOnly(10, 20))));
        }
    }
}
