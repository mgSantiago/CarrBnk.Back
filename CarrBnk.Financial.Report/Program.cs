using App.Configurations;
using CarrBnk.BaseConfiguration.Configurations;
using CarrBnk.BaseConfiguration.Middlewares;
using CarrBnk.Financial.Report.Configurations;
using CarrBnk.Financial.Report.Infra.Configurations;
using CarrBnk.Financial.Report.Infra.Consumers;
using CarrBnk.RabbitMq.Configurations;
using CarrBnk.Redis.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersionConfiguration();
builder.Services.AddMediatrConfiguration();
builder.Services.AddSwaggerConfiguration(builder.Configuration);
builder.Services.AddLogging();
builder.Services.AddHealthCheckConfiguration();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddMongoConfiguration(builder.Configuration);
builder.Services.AddRedisConfiguration(builder.Configuration);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddRabbitMqConfiguration(builder.Configuration);
builder.Services.AddValidationConfiguration();
builder.Services.AddLocalValidatorsConfiguration();
builder.Services.AddRepositoryConfiguration();
builder.Services.AddHostedService<FinancialPostingCreatedConsumer>();

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

app.UseCors(k => k.WithOrigins("http://carrbnk.com").AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.MapHealthChecks("/health");

app.MapControllers();

app.Run();

//using IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices((hostContext, services) =>
//    {
//        services.AddRabbitMqConfiguration(hostContext.Configuration);
//        services.AddMongoConfiguration(hostContext.Configuration);
//        services.AddLogging();
//        services.AddRepositoryConfiguration();
//        services.AddHostedService<FinancialPostingCreatedConsumer>();
//    })
//    .Build();

//await host.RunAsync();