using App.Configurations;
using CarrBnk.BaseConfiguration.Configurations;
using CarrBnk.BaseConfiguration.Middlewares;
using CarrBnk.Financial.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersionConfiguration();
builder.Services.AddMediatrConfiguration<Program>();
builder.Services.AddSwaggerConfiguration(builder.Configuration);
builder.Services.AddLogging();
builder.Services.AddAutomapperConfiguration();
builder.Services.AddHealthCheckConfiguration();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddMongoConfiguration(builder.Configuration);
builder.Services.AddRepoConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthy");

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
