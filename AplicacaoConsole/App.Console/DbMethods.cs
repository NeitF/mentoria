using App.Core.Context;
using App.Core.Entities;

namespace AppConsole.Methods;

public class DbMethods
{
    private readonly ApplicationDbContext _context;

    public DbMethods(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddAutor()
    {
        Console.Write("Nome do autor: ");
        var nome = Console.ReadLine();
        Autor.Add(nome, _context);
    }
    
    public void AddEditora()
    {
        Console.Write("Nome da editora: ");
        var nome = Console.ReadLine();
        Editora.Add(nome, _context);
    }
    
    public void AddLivro()
    {
        Console.Write("Titulo do livro: ");
        var titulo = Console.ReadLine();
        
       Console.Write("Ano publicacao: ");
       var anoPublicacao = int.Parse(Console.ReadLine());
       
       Console.Write("Nome do autor: ");
       var nomeAutor = Console.ReadLine();
       
       Console.Write("Nome editora: ");
       var nomeEditora = Console.ReadLine();
       
       Livro.Add(titulo, anoPublicacao, nomeAutor, nomeEditora, _context);
    }
    
    public void UpdateAutor()
    {
        Console.Write("Nome do autor: ");
        var nomeAtual = Console.ReadLine();
        
        Console.Write("Novo nome: ");
        var nomeNovo = Console.ReadLine();
        
        Autor.Update(nomeAtual, nomeNovo, _context);
    }
    
    public void UpdateEditora()
    {
        Console.Write("Nome da editora: ");
        var nomeAtual = Console.ReadLine();
        
        Console.Write("Novo nome: ");
        var nomeNovo = Console.ReadLine();
        
        Editora.Update(nomeAtual, nomeNovo, _context);
    }
    
    public void UpdateLivro()
    {
        Console.Write("Titulo do livro: ");
        var tituloAtual = Console.ReadLine();
        
        Console.Write("Novo titulo do livro: ");
        var tituloNovo = Console.ReadLine();
        
        Console.Write("Ano publicacao: ");
        var anoPublicacao = int.Parse(Console.ReadLine());
       
        Console.Write("Nome do autor: ");
        var nomeAutor = Console.ReadLine();
       
        Console.Write("Nome editora: ");
        var nomeEditora = Console.ReadLine();
       
        Livro.Update(tituloAtual, tituloNovo, anoPublicacao, nomeAutor, nomeEditora, _context);
    }
    
    public void DeleteAutor()
    {
        Console.Write("Nome do autor: ");
        var nome = Console.ReadLine();
        
        Autor.Delete(nome, _context);
    }
    
    public void DeleteEditora()
    {
        Console.Write("Nome da editora: ");
        var nome = Console.ReadLine();
        
        Editora.Delete(nome, _context);
    }
    
    public void DeleteLivro()
    {
        Console.Write("Titulo do livro: ");
        var titulo = Console.ReadLine();
        
        Livro.Delete(titulo, _context);
    }

    public void AddAll()
    {
        Console.Write("Nome do autor: ");
        var nomeAutor = Console.ReadLine();
        
        Console.Write("Nome da editora: ");
        var nomeEditora = Console.ReadLine();
        
        Console.Write("Titulo do livro: ");
        var titulo = Console.ReadLine();
        
        Console.Write("Ano publicação: ");
        var anoPublicacao = int.Parse(Console.ReadLine());
       
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            //transaction.CreateSavepoint("savePoint");
            
            Autor.Add(nomeAutor, _context);
            Editora.Add(nomeEditora, _context);
            Livro.Add(titulo, anoPublicacao, nomeAutor, nomeEditora, _context);
            
            _context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            //transaction.RollbackToSavepoint("savePoint");
            
            Console.WriteLine("FALHA NA TRANSAÇÃO");
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }

    public void DeleteAll()
    {
        var livros = _context.Livro.ToList();
        var editoras = _context.Editora.ToList();
        var autores = _context.Autor.ToList();
        
        _context.RemoveRange(livros);
        _context.RemoveRange(editoras);
        _context.RemoveRange(autores);
        
        _context.SaveChanges();
    }

    public void FiltrarPorAno()
    {
        Console.Write("Digite o ano de publicação: ");
        var ano = int.Parse(Console.ReadLine());

        Livro.FiltrarLivrosPorAno(_context, ano);
    }
}