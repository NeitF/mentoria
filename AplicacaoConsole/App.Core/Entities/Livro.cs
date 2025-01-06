using App.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Entities;

public class Livro
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public Guid AutorId { get; set; }
    public Guid EditoraId { get; set; }
    
    public Autor? Autor { get; set; }
    public Editora? Editora { get; set; }

    public Livro(string titulo, int anoPublicacao, Guid autorId, Guid editoraId, Guid id = default)
    {
        Id = id;
        Titulo = titulo;
        AnoPublicacao = anoPublicacao;
        AutorId = autorId;
        EditoraId = editoraId;
    }

    public static void Add(
        string titulo, 
        int anoPublicacao, 
        string nomeAutor, 
        string nomeEditora, 
        ApplicationDbContext context
    )
    {
        var autor = context.Autor.Single(x => x.Nome == nomeAutor);
        var editora = context.Editora.Single(x => x.Nome == nomeEditora);
        
        var entity = new Livro(titulo, anoPublicacao, autor.Id, editora.Id);
        context.Livro.Add(entity);
        context.SaveChanges();
    }

    public static void Update
    (
        string tituloAtual,
        string tituloNovo,
        int anoPublicacao, 
        string nomeAutor, 
        string nomeEditora, 
        ApplicationDbContext context
    )
    {
        var autor = context.Autor.Single(x => x.Nome == nomeAutor);
        var editora = context.Editora.Single(x => x.Nome == nomeEditora);
        
        var currentEntity = context.Livro.Single(x => x.Titulo == tituloAtual);
        var updatedEntity =  new Livro(tituloNovo, anoPublicacao, autor.Id, editora.Id, currentEntity.Id);
        context.Livro.Update(updatedEntity);
        context.SaveChanges();
    }
    
    public static void Delete(string titulo, ApplicationDbContext context)
    {
        var currentEntity = context.Livro.Single(x => x.Titulo == titulo);
        context.Livro.Remove(currentEntity);
        context.SaveChanges();
    }
    
    public static void Show(ApplicationDbContext context)
    {
        var livros = context.Livro
            .Include(x => x.Editora)
            .Include(x => x.Autor)
            .ToList();

        Console.WriteLine("LISTAGEM DE LIVROS");
        foreach (var livro in livros)
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine($"ID: {livro.Id}\n" +
                              $"TITULO: {livro.Titulo}\n" +
                              $"ANO PUBLICACAO: {livro.AnoPublicacao}\n" +
                              $"AUTOR: {livro.Autor!.Nome}\n" +
                              $"EDITORA: {livro.Editora!.Nome}");
            Console.WriteLine(new string('=', 30));
        }

        Console.ReadLine();
    }

    public static void FiltrarLivrosPorAno(ApplicationDbContext context, int anoPublicacao)
    {
        // Sintaxe de query
        // var livros =
        //     from livro in context.Livro
        //     join autor in context.Autor on livro.AutorId equals autor.Id
        //     join editora in context.Editora on livro.EditoraId equals editora.Id
        //     where livro.AnoPublicacao >= anoPublicacao
        //     select new Livro
        //     (
        //         livro.Titulo,
        //         livro.AnoPublicacao,
        //         autor.Id,
        //         editora.Id,
        //         livro.Id
        //     );
        
        // Sintaxe de método
        var livros = context.Livro
            .Include(x => x.Editora)
            .Include(x => x.Autor)
            .Where(x => x.AnoPublicacao >= anoPublicacao)
            .Select(x => new Livro(x.Titulo, x.AnoPublicacao, x.Autor.Id, x.Editora.Id, x.Id));
        
        Console.WriteLine($"LISTAGEM DE LIVROS PUBLICADO A PARTIR DE {anoPublicacao}");
        Console.WriteLine(livros.ToQueryString());
        
        foreach (var livro in livros)
        {
            Console.WriteLine(new string('=', 30));
            Console.WriteLine($"ID: {livro.Id}\n" +
                              $"TITULO: {livro.Titulo}\n" +
                              $"ANO PUBLICACAO: {livro.AnoPublicacao}\n" +
                              $"AUTOR: {livro.AutorId}\n" +
                              $"EDITORA: {livro.Editora}");
            Console.WriteLine(new string('=', 30));
        }
        Console.ReadLine();
    }
}