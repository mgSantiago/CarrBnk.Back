using CarrBnk.BaseConfiguration.Configurations;
using CarrBnk.BaseConfiguration.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLogging();
builder.Services.AddApiVersionConfiguration();
builder.Services.AddMediatrConfiguration<Program>();
builder.Services.AddSwaggerConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.MapHealthChecks("/health");

app.Run();
