using MiAppUsuarios.DataContext;
using Microsoft.EntityFrameworkCore;

using MiAppUsuarios.Repositories;
using MiAppUsuarios.Services;

var builder = WebApplication.CreateBuilder(args);
// Configurar PostgreSQL
builder.Services.AddDbContext<MiApiUsuariosDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Inyectar Repositorio y Servicio
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
