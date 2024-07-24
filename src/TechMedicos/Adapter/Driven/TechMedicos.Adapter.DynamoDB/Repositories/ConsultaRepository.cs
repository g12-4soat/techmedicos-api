using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using TechMedicos.Adapter.DynamoDB.Models;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Adapter.DynamoDB.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly IDynamoDBContext _context;
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public ConsultaRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
            _dynamoDbClient = dynamoDbClient;
        }
        public async Task<Consulta> Atualizar(Consulta consulta)
        {
            var consultaDynamoModel = await _context.LoadAsync<ConsultaDbModel>(consulta.Id);

            consultaDynamoModel.Status = consulta.Status;
            consultaDynamoModel.Justificativa = consulta.Justificativa;

            await _context.SaveAsync(consultaDynamoModel);
            return consulta;
        }

        public async Task<Consulta> Cadastrar(Consulta consulta)
        {
            var medicoDbModel =  new MedicoDbModel(
                consulta.Medico.Agendas,
                consulta.Medico.Crm,
                consulta.Medico.ValorConsulta,
                consulta.Medico.Nome
               );

            var pacienteDbModel = new PacienteDbModel(
                    consulta.Paciente.Cpf,
                    consulta.Paciente.Email,
                    consulta.Paciente.Nome
                );

            var consultaDynamoModel = new ConsultaDbModel(
                consulta.MedicoId,
                medicoDbModel,
                consulta.PacienteId,
                pacienteDbModel,
                consulta.DataConsulta,
                consulta.Status,
                consulta.Valor,
                consulta.Justificativa
               );

            await _context.SaveAsync(consultaDynamoModel);
            return consulta;
        }

        public async Task<Consulta> ObterPorId(string consultaId)
        {
            var consultaDynamoModel = await _context.LoadAsync<ConsultaDbModel>(consultaId);

            if (consultaDynamoModel is null)
                return null;

            var consulta = new Consulta
                (
                    consultaDynamoModel.Id,
                    consultaDynamoModel.MedicoId,
                    consultaDynamoModel.PacienteId,
                    consultaDynamoModel.DataConsulta,
                    consultaDynamoModel.Valor,
                    consultaDynamoModel.Status
                );

            return consulta;
        }
    }
}