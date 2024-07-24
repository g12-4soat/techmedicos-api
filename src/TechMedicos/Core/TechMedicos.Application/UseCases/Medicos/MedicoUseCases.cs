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
    }
}
