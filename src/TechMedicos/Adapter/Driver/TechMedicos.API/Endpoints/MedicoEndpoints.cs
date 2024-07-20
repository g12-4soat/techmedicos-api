﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TechMedicos.API.Constantes;
using TechMedicos.Application.DTOs;

namespace TechMedicos.API.Endpoints
{
    public static class MedicoEndpoints
    {
        public static void MapCheckoutEndpoints(this IEndpointRouteBuilder app)
        {
            //app.MapGet("api/medicos", "")
            //   .WithTags(EndpointTagConstantes.TAG_MEDICO)
            //   .WithMetadata(new SwaggerOperationAttribute(summary: "", description: ""))
            //   .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, description: ""))
            //   .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
            //   .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: ""))
            //   .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
            //   .RequireAuthorization();

            app.MapGet("api/medicos/agenda", BuscarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Obter agenda", description: "Retorna a agenda com o id informado"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(AgendaResponseDTO), description: "Agenda encontrada com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Agenda não encontrada"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapPost("api/medicos/agenda", CadastrarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar cadastro da agenda", description: "Efetua o cadastro dos horários disponiveis"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(AgendaResponseDTO), description: "Horários cadastrados com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar o cadastro"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapPut("api/medicos/agenda", AtualizarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar a atualização da agenda", description: "Efetua a atualização dos horários"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(AgendaResponseDTO), description: "Horários atualizados com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar a atualização"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapDelete("api/medicos/agenda", DeletarAgenda)
               .WithTags(EndpointTagConstantes.TAG_MEDICO)//Horário ou da agenda?
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar a exclusão da agenda", description: "Efetua a exclusão da agenda"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, description: "Agenda exlcuída com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar a exclusão"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();
        }

        private static async Task<IResult> BuscarAgenda()
        {
            return Results.Ok();
        }
        private static async Task<IResult> CadastrarAgenda()
        {
            return Results.Ok();
        }

        private static async Task<IResult> AtualizarAgenda()
        {
            return Results.Ok();
        }

        private static async Task<IResult> DeletarAgenda()
        {
            return Results.Ok();
        }
    }
}
