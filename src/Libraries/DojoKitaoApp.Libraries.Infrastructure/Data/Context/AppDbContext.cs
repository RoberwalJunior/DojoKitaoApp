using Microsoft.EntityFrameworkCore;
using DojoKitaoApp.Libraries.Domain.Entities;

namespace DojoKitaoApp.Libraries.Infrastructure.Data.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Matricula>()
            .HasOne(a => a.Aluno)
            .WithOne(a => a.Matricula)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
