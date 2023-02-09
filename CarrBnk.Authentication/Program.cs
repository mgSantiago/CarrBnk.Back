using CarrBnk.BaseConfiguration.Configurations;
using CarrBnk.BaseConfiguration.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatrConfiguration<Program>();
builder.Services.AddLogging();
builder.Services.AddSwaggerConfiguration(builder.Configuration["App.Title"], builder.Configuration["App.Version"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
