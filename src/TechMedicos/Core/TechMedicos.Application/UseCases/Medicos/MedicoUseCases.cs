using System;
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

        public static async Task<Medico> ValidarAgendaMedicaPorData(string id, DateTime dataConsulta, IMedicoGateway medicoGateway)
        {
            DateOnly dateOnly = DateOnly.FromDateTime(dataConsulta);
            TimeOnly timeOnly = TimeOnly.FromDateTime(dataConsulta);

            var medico = await VerificarMedicoExistente(id, medicoGateway);

            if (!medico.Agendas.Any())
                throw new DomainException($"Nenhuma agenda disponivel para esse médico: {id}");

            //if (!medico.Agendas.Where(x => x.Data == dateOnly && x.Horarios.Any(x => x.HoraInicio == timeOnly)).Any())
            //    throw new DomainException($"Nenhuma agenda diponivel para esse horário informado: {dataConsulta}");

            if (medico.Agendas.Any(agenda => agenda.Data == dateOnly &&
                agenda.Horarios.Any(horario => horario.HoraInicio == timeOnly)) == false)
            {
                throw new DomainException($"Nenhuma agenda disponível para esse horário informado: {dataConsulta}");
            }

            return medico;
        }
    }
}
