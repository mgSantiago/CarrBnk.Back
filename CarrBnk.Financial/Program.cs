using App.Configurations;
using CarrBnk.BaseConfiguration.Configurations;
using CarrBnk.BaseConfiguration.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatrConfiguration<Program>();
builder.Services.AddLogging();
builder.Services.AddAutomapperConfiguration();
builder.Services.AddServicesConfiguration();
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

app.MapHealthChecks("/health");

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
