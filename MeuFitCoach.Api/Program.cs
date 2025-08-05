var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("MeuFitCoachConnection");
builder .Services.AddDbContext<MeuFitCoach.Infrastructure.Persistence.Context.AppDbContext>(options =>
    options.UseNpgsql(connectionString));


var app = builder.Build();




//Injeção de Dependências
builder.Services.AddScoped<GerarPlanoDeTreinoCommand, GerarPlanoDeTreinoCommand>();




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
