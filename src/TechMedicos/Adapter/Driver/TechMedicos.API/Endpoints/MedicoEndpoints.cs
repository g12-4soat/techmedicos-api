﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TechMedicos.API.Constantes;
using TechMedicos.Application.Controllers.Interfaces;
using TechMedicos.Application.DTOs;

namespace TechMedicos.API.Endpoints
{
    public static class MedicoEndpoints
    {
        public static void MapCheckoutEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/medicos", BuscarMedicos)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Obter todos os médicos cadastrados", description: "Retorna todos os médicos"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(List<MedicoResponseDTO>), description: "Médicos encontrados com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Nenhum médico encontrado"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapGet("api/medicos/{medicoId}/agenda", BuscarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Obter agenda", description: "Retorna a agenda com o id informado"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(AgendaResponseDTO), description: "Agenda encontrada com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Agenda não encontrada"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapPost("api/medicos/{medicoId}/agenda", CadastrarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar cadastro da agenda", description: "Efetua o cadastro dos horários disponiveis"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(AgendaResponseDTO), description: "Horários cadastrados com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar o cadastro"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapPut("api/medicos/{medicoId}/agenda", AtualizarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar a atualização da agenda", description: "Efetua a atualização dos horários"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(AgendaResponseDTO), description: "Horários atualizados com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar a atualização"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapDelete("api/medicos/{medicoId}/agenda", DeletarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)//Horário ou da agenda?
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar a exclusão da agenda", description: "Efetua a exclusão da agenda"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, description: "Agenda exlcuída com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar a exclusão"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();
        }

        private static async Task<IResult> BuscarMedicos([FromServices] IMedicoController medicoController)
        {
            var medicos = await medicoController.BuscarMedicos();

            return medicos is not null
            ? Results.Ok(medicos)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao buscar médicos.", StatusCode = HttpStatusCode.BadRequest });
        }

        private static async Task<IResult> BuscarAgenda([FromRoute] int medicoId, [FromServices] IMedicoController medicoController)
        {
            var agenda = await medicoController.BuscarAgenda();

            return agenda is not null
            ? Results.Ok(agenda)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao buscar a agenda.", StatusCode = HttpStatusCode.BadRequest });
        }

        private static async Task<IResult> CadastrarAgenda([FromRoute] int medicoId, [FromBody] AgendaRequestDTO agendaDto, [FromServices] IMedicoController medicoController)
        {
            var agenda = await medicoController.CadastrarAgenda();

            return agenda is not null
            ? Results.Created("api/medicos/{medicoId}/agenda", agenda)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao cadastrar a agenda.", StatusCode = HttpStatusCode.BadRequest });
        }

        private static async Task<IResult> AtualizarAgenda([FromRoute] int medicoId, [FromBody] AgendaRequestDTO agendaDto, [FromServices] IMedicoController medicoController)
        {
            var agenda = await medicoController.AtualizarAgenda();

            return agenda is not null
            ? Results.Ok(agenda)
            : Results.BadRequest(new ErrorResponseDTO { MensagemErro = "Erro ao atualizar a agenda.", StatusCode = HttpStatusCode.BadRequest });
        }

        private static async Task<IResult> DeletarAgenda([FromRoute] int medicoId, [FromServices] IMedicoController medicoController)
        {
            await medicoController.DeletarAgenda();
            return Results.Ok();
        }
    }
}