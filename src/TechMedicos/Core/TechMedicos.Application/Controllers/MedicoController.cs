using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.DTOs;

namespace TechMedicos.Application.Controllers
{
    public class MedicoController : IMedicoController
    {
        public Task<AgendaMedicaResponseDTO> AtualizarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios)
        {
            //obter o médico para validar se ele existe
            //ajustar na entidade um método para atualizar a agenda, com base na data, filtrando a lista pela data e sobrescrevendo com os novos horários
            //chamar o gateway pra atualizar
            throw new NotImplementedException();
        }

        public Task<AgendaMedicaResponseDTO> BuscarAgenda(string medicoId)
        {
            //obter o médico para validar se ele existe
            throw new NotImplementedException();
        }

        public Task<List<MedicoResponseDTO>> BuscarMedicos()
        {
            throw new NotImplementedException();
        }

        public Task<AgendaMedicaResponseDTO> CadastrarAgenda(string medicoId, DateOnly data, List<HorarioDisponivelRequestDTO> horarios)
        {
            //obter o médico para validar se ele existe

            throw new NotImplementedException();
        }

        public Task DeletarAgenda(string medicoId, DateOnly data)
        {
            //obter o médico para validar se ele existe
            throw new NotImplementedException();
        }
    }
}
