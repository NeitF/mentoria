using App.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Context;

public class ApplicationDbContext : DbContext
{
    public string DbPath { get; }
    public ApplicationDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "livraria.db");
    }
    
    public DbSet<Autor> Autor { get; set; }
    public DbSet<Livro> Livro { get; set; }
    public DbSet<Editora> Editora { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}