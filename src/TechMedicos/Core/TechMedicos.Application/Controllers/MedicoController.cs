using Mapster;
using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.DTOs;
using TechMedicos.Application.Gateways;
using TechMedicos.Application.Gateways.Interfaces;
using TechMedicos.Application.Ports.Repositories;
using TechMedicos.Application.UseCases.Medicos;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.Application.Controllers
{
    public class MedicoController : IMedicoController
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMedicoGateway _medicoGateway;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
            _medicoGateway = new MedicoGateway(medicoRepository);
        }

        public async Task<AgendaMedicaResponseDTO> AtualizarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios)
        {
            var horariosVO = horarios.Adapt<List<HorarioDisponivel>>();
            var medico = await MedicoUseCases.AtualizarAgenda(medicoId, data, horariosVO, _medicoGateway);
            return medico.Adapt<AgendaMedicaResponseDTO>();
        }

        public async Task<AgendaMedicaResponseDTO> BuscarAgenda(string medicoId)
        {
            var medico = await MedicoUseCases.VerificarMedicoExistente(medicoId, _medicoGateway);
            if (!medico.Agendas.Any())
                return null;

            return medico.Adapt<AgendaMedicaResponseDTO>();
        }

        public async Task<List<MedicoResponseDTO>> BuscarMedicos()
        {
            var medicos = await _medicoGateway.ObterTodos();
            return medicos.Adapt<List<MedicoResponseDTO>>();
        }

        public async Task<AgendaMedicaResponseDTO> CadastrarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios)
        {
            var horariosVO = horarios.Adapt<List<HorarioDisponivel>>();
            var medico = await MedicoUseCases.CadastrarAgenda(medicoId, data, horariosVO, _medicoGateway);
            return medico.Adapt<AgendaMedicaResponseDTO>();
        }

        public async Task DeletarAgenda(string medicoId, DateOnly data)
        {
            await MedicoUseCases.DeletarAgenda(medicoId, data, _medicoGateway);
        }
    }
}