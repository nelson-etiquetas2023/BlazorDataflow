using Dataflow.Server.Data;
using Dataflow.Server.Repository.Implementations;
using Dataflow.Server.Repository.Interfaces;
using Dataflow.Server.Service.Contracts;
using Dataflow.Server.Service.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion del AppDbConext.
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer("name=DefaultConnection"));
//Inyeccion del Repository Manager.
builder.Services.AddScoped<IrepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

var app = builder.Build();

//Configuracion de los CORS.
app.UseCors(x => x
	.AllowAnyMethod()
	.AllowAnyHeader()
	.SetIsOriginAllowed(origin => true)
	.AllowCredentials()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
