using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TechMedicos.API.Constantes;
using TechMedicos.Application.DTOs;

namespace TechMedicos.API.Endpoints
{
    public static class ConsultaEndpoints
    {
        public static void MapCheckoutEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPut("api/consultas/{id}/status", AtualizarConsulta)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar atualização de status da consulta", description: "Efetua a atualização do status"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, description: "Status atualizado com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar a atualização do status"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapGet("api/consultas/{id}", BuscarConsultaPorId)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Obter consulta por id", description: "Retorna a consulta com o id informado"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(ConsultaResponseDTO), description: "Consulta encontrada com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Consulta não encontrada"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapPost("api/consultas", CadastrarConsulta)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Realizar cadastro da consulta", description: "Efetua a criação da consulta"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, description: "Consulta criada com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Falha ao realizar a criação da consulta"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();

            app.MapGet("api/consultas", BuscarConsultaPorMedico)
               .WithTags(EndpointTagConstantes.TAG_CONSULTA)
               .WithMetadata(new SwaggerOperationAttribute(summary: "Obter consultas por médicos", description: "Retorna as consultas com o médico informado"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.OK, type: typeof(ConsultaResponseDTO), description: "Consulta encontrada com sucesso"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.BadRequest, type: typeof(ErrorResponseDTO), description: "Requisição inválida"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.NotFound, type: typeof(ErrorResponseDTO), description: "Nenhuma consulta encontrada"))
               .WithMetadata(new SwaggerResponseAttribute((int)HttpStatusCode.InternalServerError, type: typeof(ErrorResponseDTO), description: "Erro no servidor interno"))
               .RequireAuthorization();
        }

        private static async Task<IResult> AtualizarConsulta([FromRoute] int id)
        {
            return Results.Ok();
        }
        private static async Task<IResult> BuscarConsultaPorId([FromRoute] int id)
        {
            return Results.Ok();
        }

        private static async Task<IResult> CadastrarConsulta()
        {
            return Results.Ok();
        }

        private static async Task<IResult> BuscarConsultaPorMedico()
        {
            return Results.Ok();
        }
    }
}
