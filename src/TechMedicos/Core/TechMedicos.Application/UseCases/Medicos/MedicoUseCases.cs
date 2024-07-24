using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Application.UseCases.Medicos
{
    public class MedicoUseCases
    {
        public static async Task<Medico> CadastrarAgenda(string medicoId, DateOnly data, List<HorarioDisponivel> horarios,
          IMedicoGateway medicoGateway)
        {
            var medico = await VerificarMedicoExistente(medicoId, medicoGateway);
            medico.AdicionarAgendamento(new AgendaMedica(data, horarios));
            await medicoGateway.Atualizar(medico);
            return medico;
        }
        public static async Task<Medico> AtualizarAgenda(string medicoId, DateOnly data, List<HorarioDisponivel> horarios,
            IMedicoGateway medicoGateway)
        {
            var medico = await VerificarMedicoExistente(medicoId, medicoGateway);
            medico.AtualizarAgendamento(new AgendaMedica(data, horarios));
            await medicoGateway.Atualizar(medico);
            return medico;
        }

        public static async Task<Medico> DeletarAgenda(string medicoId, DateOnly data,
            IMedicoGateway medicoGateway)
        {
            var medico = await VerificarMedicoExistente(medicoId, medicoGateway);
            medico.DeletarAgendamento(data);
            await medicoGateway.Atualizar(medico);
            return medico;
        }
        public static async Task<Medico> VerificarMedicoExistente(string id, IMedicoGateway medicoGateway)
        {
            var medico = await medicoGateway.ObterPorId(id);

            if (medico is null)
                throw new DomainException($"Médico não encontrado para o id: {id}");

            return medico;
        }
    }
}
