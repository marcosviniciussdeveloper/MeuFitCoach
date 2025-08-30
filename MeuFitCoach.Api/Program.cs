using System.Reflection;
using MeuFitCoach.Application.Interface.Infrastructure;
using MeuFitCoach.Application.Interface.Persistence;
using MeuFitCoach.Infrastructure.Configuration;
using MeuFitCoach.Infrastructure.Integrations;
using MeuFitCoach.Infrastructure.Integrations.Services;
using Microsoft.EntityFrameworkCore;
using MeuFitCoach.Application.Mappers;
using Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("MeuFitCoachConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.Configure<TwilioSettings>
(builder.Configuration.GetSection("Twilio"));


//Injeção de Dependências
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IWhatsAppService , WhatsappService>();


var app = builder.Build();




//Injeção de Dependências
//builder.Services.AddScoped<WhatsAppService , WhatsAppService>();




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
