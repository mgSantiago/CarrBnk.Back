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
builder.Services.AddMediatrConfiguration();

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
