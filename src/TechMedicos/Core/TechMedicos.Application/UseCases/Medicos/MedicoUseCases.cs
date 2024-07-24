using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.UseCases.Medicos
{
    public class MedicoUseCases
    {
        public static async Task<Medico> VerificarMedicoExistente(string id, IMedicoGateway medicoGateway)
        {
            var medico = await medicoGateway.ObterPorId(id);

            if (medico is null)
                throw new DomainException($"Médico não encontrado para o id: {id}");

            return medico;
        }

        public static async Task<Medico> ValidarAgendaMedicaPorData(string id, DateTime dataConsulta, IMedicoGateway medicoGateway)
        {
            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);

            var medico = await VerificarMedicoExistente(id, medicoGateway);

            if (!medico.Agendas.Any())
                throw new DomainException($"Nenhuma agenda disponivel para esse médico: {id}");

            if (!medico.Agendas.Where(x => x.Data == dateOnly && x.Horarios.Any(x => x.HoraInicio == timeOnly)).Any())
                throw new DomainException($"Nenhuma agenda diponivel para esse horário informado: {dataConsulta}");

            return medico;
        }
    }
}
