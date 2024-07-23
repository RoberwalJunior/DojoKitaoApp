using Microsoft.EntityFrameworkCore;
using DojoKitaoApp.Libraries.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DojoKitaoApp.Libraries.Infrastructure.Data.Modelos;

namespace DojoKitaoApp.Libraries.Infrastructure.Data.Context;

public class AppDbContext(DbContextOptions options) 
    : IdentityDbContext<UsuarioComAcesso, PerfilDeAcesso, int>(options)
{
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<Aula> Aulas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Endereco>()
            .HasOne(a => a.Aluno)
            .WithOne(a => a.Endereco)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Aula>()
            .HasKey(aula => new { aula.TreinoId, aula.AlunoId });

        modelBuilder.Entity<Aula>()
            .HasOne(aula => aula.Aluno)
            .WithMany(aluno => aluno.Aulas)
            .HasForeignKey(aula => aula.AlunoId);

        modelBuilder.Entity<Aula>()
            .HasOne(aula => aula.Treino)
            .WithMany(treino => treino.Aulas)
            .HasForeignKey(aula => aula.TreinoId);
    }
}
