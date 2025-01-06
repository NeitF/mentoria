using BusinessLogic;
using BusinessLogic.AutorBll;
using DataAccess.Domain;

namespace AppConsole.Metodos;

public class AutoresMethods
{
    public static void IncluirAutor()
    {
        using (var bll = new AutorBusinessLogic())
        {
            Autor autor = new Autor();
            Console.WriteLine("Informe o nome do autor: ");
            string nome = Console.ReadLine();
            autor.Nome = nome;
            bll.AddAutor(autor);
        }
    }

    public static void AtualizarAutor()
    {
        using (var bll = new AutorBusinessLogic())
        {
            Console.Write("Nome do autor: ");
            var nomeAtual = Console.ReadLine();
            var autor = bll.GetAutorByName(nomeAtual);
            
            Console.Write("Novo nome: ");
            var nomeNovo = Console.ReadLine();
            autor.Nome = nomeNovo;
            
            bll.UpdateAutor(autor);
        }
    }

    public static void ExcluirAutor()
    {
        using (var bll = new AutorBusinessLogic())
        {
            Console.Write("Nome do autor: ");
            var nomeAtual = Console.ReadLine();
            var autor = bll.GetAutorByName(nomeAtual);
            bll.DeleteAutor(autor);
        }
    }
    
    public static void ListarAutores()
    {
        using (var bll = new AutorBusinessLogic())
        {
            var autores = bll.GetAutores();
            foreach (var autor in autores)
            {
                Console.WriteLine(new string('=', 30));
                Console.WriteLine($"ID:{autor.Id}\nNome: {autor.Nome}");
                Console.WriteLine(new string('=', 30));
            }
        }
        Console.ReadLine();
    }
}