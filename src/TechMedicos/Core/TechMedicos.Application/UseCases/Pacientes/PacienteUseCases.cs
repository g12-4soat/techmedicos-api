using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;

namespace TechMedicos.Application.UseCases.Pacientes
{
    public class PacienteUseCases
    {
        public static async Task<Paciente> VerificarPacienteExistente(string id, IPacienteGateway pacienteGateway)
        {
            var paciente = await pacienteGateway.ObterPorId(id);

            if (paciente is null)
                throw new DomainException($"Médico não encontrado para o id: {id}");

            return paciente;
        }
    }
}
