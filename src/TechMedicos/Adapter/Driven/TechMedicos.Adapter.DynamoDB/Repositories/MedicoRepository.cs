using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using TechMedicos.Adapter.DynamoDB.Models;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Adapter.DynamoDB.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        private readonly IDynamoDBContext _context;
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public MedicoRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
            _dynamoDbClient = dynamoDbClient;
        }
        public async Task<Medico> Atualizar(Medico medico)
        {
            var medicoDynamoModel = await _context.LoadAsync<MedicoDbModel>(medico.Id);

            medicoDynamoModel.Agendamentos = medico.Agendas.ToList();

            await _context.SaveAsync(medicoDynamoModel);
            return medico;
        }

        public async Task<Medico> Cadastrar(Medico medico)
        {
            var medicoDynamoModel = new MedicoDbModel(
                medico.Agendas,
                medico.Crm,
                medico.ValorConsulta,
                medico.Nome
               );

            await _context.SaveAsync(medicoDynamoModel);
            return medico;
        }

        public async Task<Medico> ObterPorId(string medicoId)
        {
            var medicoDynamoModel = await _context.LoadAsync<MedicoDbModel>(medicoId);

            if (medicoDynamoModel is null)
                return null;

            var medico = new Medico
                (
                    medicoDynamoModel.Id,
                    medicoDynamoModel.Nome,
                    medicoDynamoModel.Crm,
                    medicoDynamoModel.ValorConsulta,
                    medicoDynamoModel.DistanciaKm,
                    medicoDynamoModel.Avaliacao,
                    medicoDynamoModel.Especialidade,
                    medicoDynamoModel.Agendamentos?.ToList() ?? new List<AgendaMedica>()
                );

            return medico;
        }

        public async Task<List<Medico>> ObterTodos()
        {
            var scanConditions = new List<ScanCondition>();
            var search = _context.ScanAsync<MedicoDbModel>(scanConditions);
            var medicoDbModels = await search.GetRemainingAsync();

            if (medicoDbModels is null)
                return null;

            var medicos = medicoDbModels.Select(medicoDynamoModel => new Medico
                (
                    medicoDynamoModel.Id,
                    medicoDynamoModel.Nome,
                    medicoDynamoModel.Crm,
                    medicoDynamoModel.ValorConsulta,
                    medicoDynamoModel.DistanciaKm,
                    medicoDynamoModel.Avaliacao,
                    medicoDynamoModel.Especialidade,
                    medicoDynamoModel.Agendamentos?.ToList() ?? new List<AgendaMedica>()
                )
            ).ToList();

            return medicos;
        }
    }
}