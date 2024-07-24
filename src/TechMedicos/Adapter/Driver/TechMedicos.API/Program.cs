using TechMedicos.API.Configuration;
using TechMedicos.Adapter.AWS.SecretsManager;

var builder = WebApplication.CreateBuilder(args);

//AWS Secrets Manager
builder.WebHost.ConfigureAppConfiguration(((_, configurationBuilder) =>
{
    configurationBuilder.AddAmazonSecretsManager("us-east-1", "lambda-auth-credentials");
}));

builder.Services.Configure<TechLanchesCognitoSecrets>(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add cognito auth
builder.Services.AddAuthenticationConfig();

//Setting Swagger
builder.Services.AddSwaggerConfiguration();

//DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

//Setting mapster
builder.Services.RegisterMaps();


builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddCustomMiddlewares();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerConfiguration();
app.AddHealthCheckEndpoint();

app.UseMapEndpointsConfiguration();

app.UseStaticFiles();

app.Run();
