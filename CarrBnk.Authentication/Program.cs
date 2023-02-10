using CarrBnk.Authentication.Core.UseCase;
using CarrBnk.Authentication.Core.UseCase.Dtos;
using CarrBnk.Authentication.Infra.Configurations;
using CarrBnk.BaseConfiguration.Configurations;
using CarrBnk.BaseConfiguration.Middlewares;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLogging();
builder.Services.AddApiVersionConfiguration();
builder.Services.AddSwaggerConfiguration(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddRepositoriesConfiguration();
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
builder.Services.AddServicesConfiguration();
builder.Services.AddMediatR(typeof(LoginUseCase));
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.MapHealthChecks("/health");

app.MapControllers();

app.Run();
