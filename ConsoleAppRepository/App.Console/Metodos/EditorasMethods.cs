using BusinessLogic.EditoraBll;
using DataAccess.Domain;

namespace AppConsole.Metodos;

public class EditorasMethods
{
    public static void IncluirEditora()
    {
        using (var bll = new EditoraBusinessLogic())
        {
            Editora editora = new Editora();
            Console.Write("Nome da editora: ");
            string nome = Console.ReadLine();
            editora.Nome = nome;
            bll.AddEditora(editora);
        }
    }
    
    public static void AtualizarEditora()
    {
        using (var bll = new EditoraBusinessLogic())
        {
            Console.Write("Nome da editora: ");
            var nomeAtual = Console.ReadLine();
            var editora = bll.GetEditoraByName(nomeAtual);
            
            Console.Write("Novo nome: ");
            var nomeNovo = Console.ReadLine();
            editora.Nome = nomeNovo;
            
            bll.UpdateEditora(editora);
        }
    }
    
    public static void ExcluirEditora()
    {
        using (var bll = new EditoraBusinessLogic())
        {
            Console.Write("Nome da editora: ");
            var nomeAtual = Console.ReadLine();
            var editora = bll.GetEditoraByName(nomeAtual);
            bll.DeleteEditora(editora);
        }
    }
    
    public static void ListarEditoras()
    {
        using (var bll = new EditoraBusinessLogic())
        {
            var editoras = bll.GetEditoras();
            foreach (var editora in editoras)
            {
                Console.WriteLine(new string('=', 30));
                Console.WriteLine($"ID:{editora.Id}\nNome: {editora.Nome}");
                Console.WriteLine(new string('=', 30));
            }
        }
        Console.ReadLine();
    }
}