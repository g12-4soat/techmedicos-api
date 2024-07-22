using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using TechMedicos.Adapter.DynamoDB.Models;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Adapter.DynamoDB.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IDynamoDBContext _context;
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public PacienteRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
            _dynamoDbClient = dynamoDbClient;
        }
        public async Task<Paciente> ObterPorId(string pacienteId)
        {
            var pacienteDynamoModel = await _context.LoadAsync<PacienteDbModel>(pacienteId);

            if (pacienteDynamoModel is null)
                return null;

            var paciente = new Paciente
                (
                    pacienteDynamoModel.Id,
                    pacienteDynamoModel.Nome,
                    pacienteDynamoModel.Senha,
                    pacienteDynamoModel.Cpf,
                    pacienteDynamoModel.Email
                );

            return paciente;
        }
    }
}