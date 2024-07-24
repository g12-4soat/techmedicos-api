using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TechMedicos.API.Constantes;
using TechMedicos.Application.Controllers;
using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.DTOs;

namespace TechMedicos.API.Endpoints
{
    public static class ConsultaEndpoints
    {
        public static void MapCheckoutEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/consultas", CadastrarConsulta)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar cadastro da consulta", description: "Efetua a criação da consulta"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.Created, description: "Consulta criada com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar a criação da consulta"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapPut("api/consultas/{consultaId}/status", AtualizarConsulta)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar atualização de status da consulta", description: "Efetua a atualização do status"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, description: "Status atualizado com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Consulta não encontrada"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapGet("api/consultas/{consultaId}", BuscarConsultaPorId)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Obter consulta por id", description: "Retorna a consulta com o id informado"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(ConsultaResponseDTO), description: "Consulta encontrada com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Consulta não encontrada"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapGet("api/consultas", BuscarConsultas)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Obter todas as consultas", description: "Retorna todas as consultas cadastradas"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(List<ConsultaResponseDTO>), description: "Consultas encontradas com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Consulta não encontrada"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();
        }

        private static async Task<IResult> CadastrarConsulta([FromBody] ConsultaCadastrarRequestDTO consultaDto, [FromServices] IConsultaController consultaController)
        {
            var consulta = await consultaController.CadastrarConsulta(
                consultaDto.MedicoId,
                consultaDto.PacienteId,
                consultaDto.DataConsulta);

            return consulta is not null
            ? Results.Created("api/consultas", consulta)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao cadastrar a consulta.", StatusCode = HttpStatusCode.BadRequest });
        }

        private static async Task<IResult> AtualizarConsulta([FromRoute] string consultaId, [FromBody] ConsultaAtualizarRequestDTO consultaDto, [FromServices] IConsultaController consultaController)
        {
            var consulta = await consultaController.AtualizarConsulta(
                consultaId,
                consultaDto.Status,
                consultaDto.Justificativa);

            return consulta is not null
            ? Results.Ok(consulta)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao atualizar a consulta.", StatusCode = HttpStatusCode.BadRequest });
        }

        private static async Task<IResult> BuscarConsultaPorId([FromRoute] string consultaId, [FromServices] IConsultaController consultaController)
        {
            var consulta = await consultaController.BuscarConsultaPorId(consultaId);

            return consulta is not null
            ? Results.Ok(consulta)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao buscar a consulta.", StatusCode = HttpStatusCode.BadRequest });
        }

        private static async Task<IResult> BuscarConsultas([FromServices] IConsultaController consultaController)
        {
            var consultas = await consultaController.BuscarConsultas();

            return consultas is not null
            ? Results.Ok(consultas)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao buscar consultas.", StatusCode = HttpStatusCode.BadRequest });
        }
    }
}
