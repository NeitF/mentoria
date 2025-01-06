using BusinessLogic.LivroBll;
using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppConsole.Metodos;

public class LivrosMethods
{
    
    #region Add
    public static void IncluirLivro()
    {
        using (var bll = new LivroBusinessLogic())
        {
            Livro livro = new Livro();
            Console.Write("Titulo do livro: ");
            string titulo = Console.ReadLine();
            
            Console.Write("Ano publicacao: ");
            var anoPublicacao = int.Parse(Console.ReadLine());
            
            Console.Write("Nome do autor: ");
            var nomeAutor = Console.ReadLine();
            
            Console.Write("Nome editora: ");
            var nomeEditora = Console.ReadLine();
            
            livro.Titulo = titulo;
            livro.AnoPublicacao = anoPublicacao;
            
            bll.AddLivro(livro, nomeAutor, nomeEditora);
        }
    }

    public static void SimularBulkInsert()
    {
        using (var bll = new LivroBusinessLogic())
        {
            bll.SimularBulkInsert();
        }
    }

    public static void SimularAddRange()
    {
        using (var bll = new LivroBusinessLogic())
        {
            bll.SimularAddRange();
        }
    }

    #endregion

    #region Update
    public static void AtualizarLivro()
    {
        using (var bll = new LivroBusinessLogic())
        {
            Console.Write("Titulo do livro: ");
            var tituloAtual = Console.ReadLine();
            var livro = bll.GetLivroByTitulo(tituloAtual);
            
            Console.Write("Novo titulo do livro: ");
            var tituloNovo = Console.ReadLine();
            
            Console.Write("Ano publicacao: ");
            var anoPublicacao = int.Parse(Console.ReadLine());
            
            Console.Write("Nome do autor: ");
            var nomeAutor = Console.ReadLine();
       
            Console.Write("Nome editora: ");
            var nomeEditora = Console.ReadLine();
            
            livro.Titulo = tituloNovo;
            livro.AnoPublicacao = anoPublicacao;
            
            bll.UpdateLivro(livro, nomeAutor, nomeEditora);
        }
    }
    
    public static void SimularBulkUpdate()
    {
        using (var bll = new LivroBusinessLogic())
        {
            bll.SimularBulkUpdate();
        }
    }
    
    public static void SimularUpdateRange()
    {
        using (var bll = new LivroBusinessLogic())
        {
            bll.SimularUpdateRange();
        }
    }
    
    #endregion

    #region Delete
    public static void ExcluirLivro()
    {
        using (var bll = new LivroBusinessLogic())
        {
            Console.Write("Titulo do livro: ");
            var tituloAtual = Console.ReadLine();
            var livro = bll.GetLivroByTitulo(tituloAtual);
            bll.DeleteLivro(livro);
        }
    }
    
    public static void BulkDelete()
    {
        using (var bll = new LivroBusinessLogic())
        {
            bll.BulkDelete();
        }
    }

    public static void RemoveRange()
    {
        using (var bll = new LivroBusinessLogic())
        {
            bll.RemoveRange();
        }
    }
    #endregion

    #region Get
    public static void ListarLivros()
    {
        using (var bll = new LivroBusinessLogic())
        {
            var livros = bll.GetLivros()
                .Include(x => x.Autor)
                .Include(x => x.Editora);
            
            foreach (var livro in livros)
            {
                Console.WriteLine(new string('=', 30));
                Console.WriteLine($"ID:{livro.Id}\n" +
                                  $"Titulo: {livro.Titulo}\n" +
                                  $"ISBN: {livro.ISBN}\n" +
                                  $"Ano de publicacao: {livro.AnoPublicacao}\n" +
                                  $"Autor: {livro.Autor!.Nome}\n" +
                                  $"Editora: {livro.Editora!.Nome}");
                Console.WriteLine(new string('=', 30));
            }
        }
        Console.ReadLine();
    }
    #endregion
    
    

    

    
    
    
}