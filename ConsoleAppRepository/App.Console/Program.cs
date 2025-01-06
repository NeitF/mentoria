using AppConsole;
using AppConsole.Enum;
using AppConsole.Metodos;
using DataAccess.Context;
using DataAccess.Domain;

public class ConsoleProgram
{
    public static void Main(string[] args)
    {
        using var context = new ApplicationDbContext();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sistema Biblioteca'\n");
            
            ExibirMenuOpcoesGerais();
            Enum.TryParse(Console.ReadLine(), true, out OpcoesGeraisMenuEnum opcao);
            ProcessarEscolhaMenuGeral(opcao, context);
        }
    }
    
    #region exibição menu
    internal static void ExibirMenuOpcoesGerais()
    {
        Console.WriteLine(new string('=', 30));

        Console.WriteLine("Menu:");
        Console.WriteLine("1 - Autores\n" +
                          "2 - Editoras\n" +
                          "3 - Livros\n" +
                          "4 - Limpar banco\n" +
                          "0 - Sair");

        Console.WriteLine(new string('=', 30));
    }
    
    internal static void ExibirMenuOpcoesAutor()
    {
        Console.WriteLine(new string('=', 30));

        Console.WriteLine("Menu Autor:");
        Console.WriteLine("1 - Add autor\n" +
                          "2 - Update autor\n" +
                          "3 - Delete autor\n" +
                          "4 - Listar autores\n" +
                          "0 - Sair");

        Console.WriteLine(new string('=', 30));
    }
    
    internal static void ExibirMenuOpcoesEditora()
    {
        Console.WriteLine(new string('=', 30));

        Console.WriteLine("Menu Editora:");
        Console.WriteLine("1 - Add editora\n" +
                          "2 - Update editora\n" +
                          "3 - Delete editora\n" +
                          "4 - Listar editoras\n" +
                          "0 - Sair");

        Console.WriteLine(new string('=', 30));
    }
    
    internal static void ExibirMenuOpcoesLivro()
    {
        Console.WriteLine(new string('=', 30));

        Console.WriteLine("Menu Livros:");
        Console.WriteLine("1 - Add livro\n" +
                          "2 - Update livro\n" +
                          "3 - Delete livro\n" +
                          "4 - Listar livros\n" +
                          "5 - Simular grande carga de livros com Bulk Insert\n" +
                          "6 - Simular grande carga de livros com Add Range\n" +
                          "7 - Simular atualização de grande quantia de registros com Bulk Update\n" +
                          "8 - Simular atualização de grande quantia de registros com Update Range\n" +
                          "9 - Apagar todos os registros de livro com Bulk Delete\n" +
                          "10 - Apagar todos os registros de livro com Remove Range\n" +
                          "0 - Sair");

        Console.WriteLine(new string('=', 30));
    }
    
    #endregion
    
    #region processamento escolha

    #region autores
    internal static void ProcessarEscolhaMenuAutores(OpcoesAutorMenuEnum opcao)
    {
        Console.Clear();
        switch (opcao)
        {
            case OpcoesAutorMenuEnum.AddAutor:
                AutoresMethods.IncluirAutor();
                break;
            case OpcoesAutorMenuEnum.UpdateAutor:
                AutoresMethods.AtualizarAutor();
                break;
            case OpcoesAutorMenuEnum.DeleteAutor:
                AutoresMethods.ExcluirAutor();
                break;
            case OpcoesAutorMenuEnum.ShowAutor:
                AutoresMethods.ListarAutores();
                break;
            case OpcoesAutorMenuEnum.Sair:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("A opção digitada não é válida");
                Console.ReadKey();
                break;
        }
    }
    
    #endregion

    #region editoras
    internal static void ProcessarEscolhaMenuEditoras(OpcoesEditoraMenuEnum opcao)
    {
        Console.Clear();
        switch (opcao)
        {
            case OpcoesEditoraMenuEnum.AddEditora:
                EditorasMethods.IncluirEditora();
                break;
            case OpcoesEditoraMenuEnum.UpdateEditora:
                EditorasMethods.AtualizarEditora();
                break;
            case OpcoesEditoraMenuEnum.DeleteEditora:
                EditorasMethods.ExcluirEditora();
                break;
            case OpcoesEditoraMenuEnum.ShowEditora:
                EditorasMethods.ListarEditoras();
                break;
            case OpcoesEditoraMenuEnum.Sair:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("A opção digitada não é válida");
                Console.ReadKey();
                break;
        }
    }
    #endregion

    #region livros
    
    internal static void ProcessarEscolhaMenuLivros(OpcoesLivroMenuEnum opcao)
    {
        Console.Clear();
        switch (opcao)
        {
            case OpcoesLivroMenuEnum.AddLivro:
                LivrosMethods.IncluirLivro();
                break;
            case OpcoesLivroMenuEnum.UpdateLivro:
                LivrosMethods.AtualizarLivro();
                break;
            case OpcoesLivroMenuEnum.DeleteLivro:
                LivrosMethods.ExcluirLivro();
                break;
            case OpcoesLivroMenuEnum.ShowLivro:
                LivrosMethods.ListarLivros();
                break;
            case OpcoesLivroMenuEnum.ApagarTodosLivrosBulkDelete:
                LivrosMethods.BulkDelete();
                break;
            case OpcoesLivroMenuEnum.ApagarTodosLivrosRemoveRange:
                LivrosMethods.RemoveRange();
                break;
            case OpcoesLivroMenuEnum.BulkInsertLivro:
                LivrosMethods.SimularBulkInsert();
                break;
            case OpcoesLivroMenuEnum.AddRangeLivro:
                LivrosMethods.SimularAddRange();
                break;
            case OpcoesLivroMenuEnum.BulkUpdateLivro:
                LivrosMethods.SimularBulkUpdate();
                break;
            case OpcoesLivroMenuEnum.UpdateRangeLivro:
                LivrosMethods.SimularUpdateRange();
                break;
            case OpcoesLivroMenuEnum.Sair:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("A opção digitada não é válida");
                Console.ReadKey();
                break;
        }
    }
    #endregion
    
    #region Menu geral
    internal static void ProcessarEscolhaMenuGeral(OpcoesGeraisMenuEnum opcoesGerais, ApplicationDbContext context)
    {
        Console.Clear();
        switch (opcoesGerais)
        {
            case OpcoesGeraisMenuEnum.MenuAutores:
                ExibirMenuOpcoesAutor();
                Enum.TryParse(Console.ReadLine(), true, out OpcoesAutorMenuEnum opcaoAutor);
                ProcessarEscolhaMenuAutores(opcaoAutor);
                break;
            case OpcoesGeraisMenuEnum.MenuEditoras:
                ExibirMenuOpcoesEditora();
                Enum.TryParse(Console.ReadLine(), true, out OpcoesEditoraMenuEnum opcaoEditora);
                ProcessarEscolhaMenuEditoras(opcaoEditora);
                break;
            case OpcoesGeraisMenuEnum.MenuLivros:
                ExibirMenuOpcoesLivro();
                Enum.TryParse(Console.ReadLine(), true, out OpcoesLivroMenuEnum opcaoLivro);
                ProcessarEscolhaMenuLivros(opcaoLivro);
                break;
            case OpcoesGeraisMenuEnum.LimparBanco:
                GlobalMethods.LimparBanco();
                break;
            case OpcoesGeraisMenuEnum.Sair:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("A opção digitada não é válida");
                Console.ReadKey();
                break;
        }
    }
    #endregion
    
    #endregion
}