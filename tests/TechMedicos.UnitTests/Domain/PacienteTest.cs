using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.UnitTests.Domain
{
    [Trait("Domain", "PacienteTest")]
    public class PacienteTest
    {
        [Fact]
        public void CriarPaciente_DeveRetornarSucesso()
        {
            // Arrange
            string nome = "Paciente Teste";
            string senha = "123456";
            string cpf = "17191721375";
            string email = "teste@gmail.com";

            // Act
            var paciente = new Paciente(nome, senha, cpf, email);

            // Assert
            Assert.Equal(nome, paciente.Nome);
            Assert.Equal(senha, paciente.Senha);
            Assert.Equal(cpf, paciente.Cpf.Numero);
            Assert.Equal(email, paciente.Email.EnderecoEmail);
        }

        [Theory]
        [InlineData("", "123456", "17191721375", "teste@gmail.com")]
        [InlineData("Paciente Teste 2", "", "17191721375", "teste@gmail.com")]
        public void CriarPaciente_Invalido_DeveLancarArgumentException(string nome, string senha, string cpf, string email)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Paciente(nome, senha, cpf, email));
        }

        [Fact]
        public void CriarPaciente_Invalido_DeveLancarDomainException()
        {
            // Arrange
            string nome = "a";
            string senha = "123456";
            string cpf = "17191721375";
            string email = "teste@gmail.com";

            // Act & Assert
            Assert.Throws<DomainException>(() => new Paciente(nome, senha, cpf, email));
        }

        [Theory]
        [InlineData("17191721374")]
        [InlineData("171917")]
        public void CriarPaciente_CpfInvalido_DeveLancarException(string cpf)
        {
            // Arrange, Act & Assert
            Assert.Throws<DomainException>(() => new Paciente("Paciente Teste 2", "123456", cpf, "teste@gmail.com"));
        }

        [Theory]
        [InlineData("teste@")]
        [InlineData("teste@a")]
        [InlineData("test")]
        public void CriarPaciente_EmailInvalido_DeveLancarException(string email)
        {
            // Arrange, Act & Assert
            Assert.Throws<DomainException>(() => new Paciente("Paciente Teste 2", "123456", "17191721375", email));
        }

        [Fact]
        public void AtualizarPaciente_DeveRetornarSucesso()
        {
            // Arrange
            string id = Guid.NewGuid().ToString();
            string nome = "Paciente Teste";
            string senha = "123456";
            string cpf = "17191721375";
            string email = "teste@gmail.com";

            // Act
            var paciente = new Paciente(id, nome, senha, cpf, email);

            // Assert
            Assert.Equal(id, paciente.Id);
            Assert.Equal(nome, paciente.Nome);
            Assert.Equal(senha, paciente.Senha);
            Assert.Equal(cpf, paciente.Cpf.Numero);
            Assert.Equal(email, paciente.Email.EnderecoEmail);
        }
    }
}
