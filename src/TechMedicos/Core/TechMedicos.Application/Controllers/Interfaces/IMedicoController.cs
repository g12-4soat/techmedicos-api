﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Application.DTOs;

namespace TechMedicos.Application.Controllers.Interfaces
{
    public interface IMedicoController
    {
        Task<List<MedicoResponseDTO>> BuscarMedicos();
        Task<AgendaMedicaResponseDTO> BuscarAgenda(int medicoId);
        Task<AgendaMedicaResponseDTO> CadastrarAgenda(int medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios);
        Task<AgendaMedicaResponseDTO> AtualizarAgenda(int medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios);
        Task DeletarAgenda(int medicoId, DateOnly data);
    }
}