using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using TechMedicos.Core;
using TechMedicos.Domain.Enums;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.API.Middlewares
{
    public class JwtTokenMiddleware : IMiddleware
    {
        private readonly ILogger<JwtTokenMiddleware> _logger;

        public JwtTokenMiddleware(
            ILogger<JwtTokenMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Get the token from the Authorization header
            var token = await context.GetTokenAsync("access_token")
                ?? context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var claimsPrincipal = ExtractClaimsFromJwt(token);

                    // Extract the user ID from the claims
                    // CPF/CRM & tipo usuário
                    var userIdClaim = claimsPrincipal.FindFirst("username");
                    var userId = userIdClaim?.Value;

                    var tipoUsuario = RetornaTipoUsuario(userId!);

                    // Store the user ID in the HttpContext items for later use
                    context.Items[nameof(TipoUsuario)] = tipoUsuario.ToString();
                }
                catch (Exception)
                {
                    // If the token is invalid, throw an exception
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Unauthorized");
                }
            }

            // Continue processing the request
            await next(context);
        }

        public TipoUsuario RetornaTipoUsuario(string userId)
        {
            bool isCpf = false;
            bool isCrm = false;

            try
            {
                var cpf = new Cpf(userId);
                isCpf = true;
            }
            catch { }

            try
            {
                if (!userId.Contains('/'))
                {
                    userId = userId.Insert(userId.Length - 2, "/");
                }

                var crm = new Crm(userId);
                isCrm = true;
            }
            catch { }

            if (!isCpf && !isCrm)
            {
                throw new DomainException("Tipo de usuário não suportado");
            }

            return isCpf
                ? TipoUsuario.Paciente
                : TipoUsuario.Medico;
        }

        private static ClaimsPrincipal ExtractClaimsFromJwt(string token)
        {
            // Decode the token to extract claims
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);

            // Create claims from the decoded token
            var claims = decodedToken.Claims.ToList();
            var identity = new ClaimsIdentity(claims, "jwt");

            // Return the claims principal
            return new ClaimsPrincipal(identity);
        }
    }
}
