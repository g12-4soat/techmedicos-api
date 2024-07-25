using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using TechMedicos.Domain.ValueObjects;

namespace TechMedicos.API.Middlewares
{
    public class JwtTokenMiddleware : IMiddleware
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<JwtTokenMiddleware> _logger;

        public JwtTokenMiddleware(
            IMemoryCache memoryCache,
            ILogger<JwtTokenMiddleware> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Get the token from the Authorization header
            var token = await context.GetTokenAsync("token_id")
                ?? context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            if (token is not null)
            {
                //put token in cache
                _memoryCache.Set("token", token, TimeSpan.FromMinutes(5));

                _logger.LogInformation("Token salvo no cache");

                try
                {
                    var claimsPrincipal = ExtractClaimsFromJwt(token);

                    // Extract the user ID from the claims
                    // CPF/CRM & tipo usuário
                    var userIdClaim = claimsPrincipal.FindFirst("username");
                    var userId = userIdClaim?.Value;

                    // Store the user ID in the HttpContext items for later use
                    context.Items[nameof(Cpf)] = userId;
                    context.Items[nameof(Crm)] = userId;
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
