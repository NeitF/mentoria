using App.Core.Context;
using App.Core.Entities;
using App.Core.Enum;
using AppConsole.Methods;

public class ConsoleProgram
{
    public static void Main(string[] args)
    {
        using var context = new ApplicationDbContext();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sistema biblioteca\n");

            ExibirMenu();
            Enum.TryParse(Console.ReadLine(), true, out OpcaoMenuEnum opcao);
            ProcessarEscolha(opcao, context);
        }
    }
    
    internal static void ExibirMenu()
    {
        Console.WriteLine(new string('=', 30));

        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Add editora\n" +
                          "2 - Add autor\n" +
                          "3 - Add livro\n" +
                          "4 - Update editora\n" +
                          "5 - Update autor\n" +
                          "6 - Update livro\n" +
                          "7 - Delete editora\n" +
                          "8 - Delete autor\n" +
                          "9 - Delete livro\n" +
                          "10 - Listar autores\n" +
                          "11 - Listar editoras\n" +
                          "12 - Listar livros\n" +
                          "13 - Adicionar todos\n" +
                          "14 - Delete todos\n" +
                          "15 - Buscar livros por ano de publicação\n" +
                          "0 - Sair");

        Console.WriteLine(new string('=', 30));
    }

    internal static void ProcessarEscolha(OpcaoMenuEnum opcao, ApplicationDbContext context)
    {
        var methods = new DbMethods(context);
        
        switch (opcao)
        {
            case OpcaoMenuEnum.AddEditora:
                methods.AddEditora();
                break;
            case OpcaoMenuEnum.AddAutor:
                methods.AddAutor();
                break;
            case OpcaoMenuEnum.AddLivro:
                methods.AddLivro();
                break;
            case OpcaoMenuEnum.UpdateEditora:
                methods.UpdateEditora();
                break;
            case OpcaoMenuEnum.UpdateAutor:
                methods.UpdateAutor();
                break;
            case OpcaoMenuEnum.UpdateLivro:
                methods.UpdateLivro();
                break;
            case OpcaoMenuEnum.DeleteEditora:
                methods.DeleteEditora();
                break;
            case OpcaoMenuEnum.DeleteAutor:
                methods.DeleteAutor();
                break;
            case OpcaoMenuEnum.DeleteLivro:
                methods.DeleteLivro();
                break;
            case OpcaoMenuEnum.ShowAutor:
                Autor.Show(context);
                break;
            case OpcaoMenuEnum.ShowEditora:
                Editora.Show(context);
                break;
            case OpcaoMenuEnum.ShowLivro:
                Livro.Show(context);
                break;
            case OpcaoMenuEnum.AddAll:
                methods.AddAll();
                break;
            case OpcaoMenuEnum.DeleteAll:
                methods.DeleteAll();
                break;
            case OpcaoMenuEnum.FilterByYear:
                methods.FiltrarPorAno();
                break;
            case OpcaoMenuEnum.Sair:
                Environment.Exit(0);
                break;
        }
    }

}