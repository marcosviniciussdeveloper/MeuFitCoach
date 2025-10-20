using MeuFitCoach.Application;
using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Application.Mappers;
using MeuFitCoach.Application.Webhook;
using MeuFitCoach.Infrastructure;
using MeuFitCoach.Infrastructure.Configuration;
using MeuFitCoach.Infrastructure.Integrations;
using MeuFitCoach.Infrastructure.Integrations.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistence;
using Supabase.Gotrue;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuração do banco de dados 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

//Injeção de dependencia do TwilioSettings
builder.Services.Configure<TwilioSettings>
(builder.Configuration.GetSection("Twilio"));


//Injeção de Dependências
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

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
app.Run();