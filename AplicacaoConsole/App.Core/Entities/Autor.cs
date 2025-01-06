using App.Core.Context;

namespace App.Core.Entities;

public class Autor
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<Livro> Livros { get; set; } = new List<Livro>();

    public Autor(string nome, Guid id = default)
    {
        Id = id;
        Nome = nome;
    }
    
    public static void Add(string nome, ApplicationDbContext context)
    {
        var entity = new Autor(nome);
        context.Autor.Add(entity);
        context.SaveChanges();
    }

    public static void Update(string nomeAtual, string novoNome, ApplicationDbContext context)
    {
        var currentEntity = context.Autor.Single(x => x.Nome == nomeAtual);
        var updatedEntity = new Autor(novoNome, currentEntity.Id);
        context.Autor.Update(updatedEntity);
        context.SaveChanges();
    }
    
    public static void Delete(string nome, ApplicationDbContext context)
    {
        var currentEntity = context.Autor.Single(x => x.Nome == nome);
        context.Autor.Remove(currentEntity);
        context.SaveChanges();
    }

    public static void Show(ApplicationDbContext context)
    {
        var autores = context.Autor.ToList();

        Console.WriteLine("LISTAGEM DE AUTORES");
        foreach (var autor in autores)
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine($"ID: {autor.Id}\n" +
                              $"NOME: {autor.Nome}");
            Console.WriteLine(new string('=', 30));
        }

        Console.ReadLine();
    }
}