using App.Core.Context;

namespace App.Core.Entities;

public class Editora
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<Livro> Livros { get; set; } = new List<Livro>();

    public Editora(string nome, Guid id = default)
    {
        Id = id;
        Nome = nome;
    }
    
    public static void Add(string nome, ApplicationDbContext context)
    {
        var entity = new Editora(nome);
        context.Editora.Add(entity);
        context.SaveChanges();
    }

    public static void Update(string nomeAtual, string nomeNovo, ApplicationDbContext context)
    {
        var currentEntity = context.Editora.Single(x => x.Nome == nomeAtual);
        var updatedEntity = new Editora(nomeNovo, currentEntity.Id);
        context.Editora.Update(updatedEntity);
        context.SaveChanges();
    }
    
    public static void Delete(string nome, ApplicationDbContext context)
    {
        var currentEntity = context.Editora.Single(x => x.Nome == nome);
        context.Editora.Remove(currentEntity);
        context.SaveChanges();
    }
    
    public static void Show(ApplicationDbContext context)
    {
        var editoras = context.Editora.ToList();
        
        Console.WriteLine("LISTAGEM DE EDITORAS");
        foreach (var editora in editoras)
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine($"ID: {editora.Id}\n" +
                              $"NOME: {editora.Nome}");
            Console.WriteLine(new string('=', 30));
        }

        Console.ReadLine();
    }
}