using Microsoft.EntityFrameworkCore;
using DojoKitaoApp.Libraries.Infrastructure.Data.Context;
using DojoKitaoApp.Libraries.Domain.Interfaces.Repositories;
using DojoKitaoApp.Libraries.Infrastructure.Data.Repositories;
using DojoKitaoApp.Libraries.Application.Interfaces;
using DojoKitaoApp.Libraries.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>((options) =>
{
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLazyLoadingProxies();
});

builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<IMatriculaRepository, MatriculaRepository>();
builder.Services.AddTransient<ITreinoRepository, TreinoRepository>();
builder.Services.AddTransient<IAulaRepository, AulaRepository>();

builder.Services.AddTransient<IAlunoServiceApi, AlunoServiceApi>();
builder.Services.AddTransient<IEnderecoServiceApi, EnderecoServiceApi>();
builder.Services.AddTransient<IMatriculaServiceApi, MatriculaServiceApi>();
builder.Services.AddTransient<ITreinoServiceApi, TreinoServiceApi>();
builder.Services.AddTransient<IAulaServiceApi, AulaServiceApi>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }