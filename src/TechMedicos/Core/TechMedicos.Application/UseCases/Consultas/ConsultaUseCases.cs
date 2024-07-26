using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Application.Gateways;
using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Application.UseCases.Medicos;
using TechMedicos.Application.UseCases.Pacientes;
using TechMedicos.Core;
using TechMedicos.Domain.Aggregates;
using TechMedicos.Domain.Enums;

namespace TechMedicos.Application.UseCases.Consultas
{
    public class ConsultaUseCases
    {
        public static async Task<Consulta> Atualizar(
            string consultaId,
            StatusConsulta statusConsulta,
            string justificativa,
            IConsultaGateway consultaGateway
            )
        {
            var consulta = await VerificarConsultaExistente(consultaId, consultaGateway);

            AtualizarStatusConsulta(consulta, statusConsulta, justificativa);

            var consultaAtualizada = await consultaGateway.Atualizar(consulta);

            return consultaAtualizada;
        }

        public static async Task<Consulta> Cadastrar(
            string medicoId,
            string pacienteId,
            DateTime dataConsulta,
            IConsultaGateway consultaGateway,
            IMedicoGateway medicoGateway,
            IPacienteGateway pacienteGateway)
        {
            var medico = await MedicoUseCases.VerificarMedicoExistente(medicoId, medicoGateway);
            var paciente = await PacienteUseCases.VerificarPacienteExistente(pacienteId, pacienteGateway);
            var consultas = await consultaGateway.ObterTodos();
            await MedicoUseCases.ValidarAgendaMedicaPorData(medicoId, dataConsulta, medicoGateway, consultas);

            var consultaJaAgendadaParaPaciente = consultas.Exists(x => x.DataConsulta.Equals(dataConsulta) && x.PacienteId == pacienteId);
            if (consultaJaAgendadaParaPaciente)
            {
                throw new DomainException($"Você já possui consulta agendada para a data informada: {dataConsulta}");
            }

            var consulta = new Consulta(medicoId, pacienteId, dataConsulta, medico.ValorConsulta);
            consulta.SetMedico(medico);
            consulta.SetPaciente(paciente);

            var novaConsulta = await consultaGateway.Cadastrar(consulta);

            return novaConsulta;
        }

        private static async Task<Consulta> VerificarConsultaExistente(string id, IConsultaGateway consultaGateway)
        {
            var consulta = await consultaGateway.ObterPorId(id);

            if (consulta is null)
                throw new DomainException($"Consulta não encontrada para o id: {id}");

            return consulta;
        }

        private static void AtualizarStatusConsulta(Consulta consulta, StatusConsulta statusConsulta, string justificativa)
        {
            switch (statusConsulta)
            {
                case StatusConsulta.Confirmada:
                    consulta.Aceitar();
                    break;
                case StatusConsulta.Rejeitada:
                    consulta.Recusar(justificativa);
                    break;
                case StatusConsulta.Cancelada:
                    consulta.Cancelar(justificativa);
                    break;
                case StatusConsulta.Realizada:
                    consulta.Realizar();
                    break;
                default:
                    throw new DomainException($"Status da consulta inválido: {statusConsulta}");
            }
        }
    }
}
