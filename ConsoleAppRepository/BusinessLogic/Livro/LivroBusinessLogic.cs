using System.Linq.Expressions;
using BusinessLogic.Extensions;
using DataAccess.Domain;
using DataAccess.Repository;

namespace BusinessLogic.LivroBll;

public class LivroBusinessLogic : IDisposable
{
    private readonly UnitOfWork _unitOfWork;

    public LivroBusinessLogic(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public LivroBusinessLogic()
    {
        _unitOfWork = new UnitOfWork();
    }
    
    #region Get
    public IQueryable<Livro> GetLivros()
    {
        return _unitOfWork.LivroRepository.Get();
    }
    
    public Livro GetLivroById(Guid livroId)
    {
        return _unitOfWork.LivroRepository.GetById(x => x.Id == livroId);
    }
    
    public Livro GetLivroByTitulo(string livroTitulo)
    {
        return _unitOfWork.LivroRepository.GetLivroPorTitulo(livroTitulo);
    }
    #endregion

    #region Add
    public void AddLivro(Livro livro, string nomeAutor, string nomeEditora)
    {
        var autor = _unitOfWork.AutorRepository.GetAutorPorNome(nomeAutor);
        var editora = _unitOfWork.EditoraRepository.GetEditoraPorNome(nomeEditora);

        livro.AutorId = autor.Id;
        livro.EditoraId = editora.Id;
        
        _unitOfWork.LivroRepository.Add(livro);
        _unitOfWork.Commit(); 
    }
    
    public void SimularBulkInsert()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var (livros, isbns, registroRepetido, novosRegistros) = GerarDados();
        Console.WriteLine($"GERAÇÃO DOS DADOS: {watch.Elapsed.TotalSeconds}");
        watch.Restart();
        _unitOfWork.LivroRepository.BulkInsert(livros);
        watch.Stop();
        
        Console.WriteLine($"IBNSs já cadastrados previamente: {registroRepetido}");
        Console.WriteLine($"Novos IBNSs cadastrados: {novosRegistros}");
        Console.WriteLine($"Método utilizado: BulkInsert\nA operação durou: {watch.Elapsed.TotalSeconds}");
        Console.ReadKey();
    }
    
    public void SimularAddRange()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var (livros, isbns, registroRepetido, novosRegistros) = GerarDados();
        Console.WriteLine($"GERAÇÃO DOS DADOS: {watch.Elapsed.TotalSeconds}");
        watch.Restart();
        _unitOfWork.LivroRepository.AddRange(livros);
        _unitOfWork.Commit();
        watch.Stop();
        
        Console.WriteLine($"IBNSs já cadastrados previamente: {registroRepetido}");
        Console.WriteLine($"Novos IBNSs cadastrados: {novosRegistros}");
        Console.WriteLine($"Método utilizado: AddRange\nA operação durou: {watch.Elapsed.TotalSeconds}");
        Console.ReadKey();
    }
    
    #endregion

    #region Delete
    public void DeleteLivro(Livro livro)
    {
        _unitOfWork.LivroRepository.Delete(livro);
        _unitOfWork.Commit();
    }
    
    public void BulkDelete()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        _unitOfWork.LivroRepository.BulkDelete();
        watch.Stop();
        Console.WriteLine($"Método utilizado: BulkDelete\nA operação durou: {watch.Elapsed.TotalSeconds}");
        Console.ReadKey();
    }

    public void RemoveRange()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        _unitOfWork.LivroRepository.RemoveRange();
        _unitOfWork.Commit();
        watch.Stop();
        Console.WriteLine($"Método utilizado: RemoveRange\nA operação durou: {watch.Elapsed.TotalSeconds}");
        Console.ReadKey();
    }

    

    #endregion

    #region Update
    public void UpdateLivro(Livro livro, string nomeAutor, string nomeEditora)
    {
        var autor = _unitOfWork.AutorRepository.GetAutorPorNome(nomeAutor);
        var editora = _unitOfWork.EditoraRepository.GetEditoraPorNome(nomeEditora);

        livro.AutorId = autor.Id;
        livro.EditoraId = editora.Id;
        
        _unitOfWork.LivroRepository.Update(livro);
        _unitOfWork.Commit();
    }
    
    public void SimularBulkUpdate()
    {
        var livros = _unitOfWork.LivroRepository.Get().ToList();

        livros.ForEach(x => x.Titulo = $"{x.Titulo} - atualizado com BulkUpdate");
        
        var watch = System.Diagnostics.Stopwatch.StartNew();
        _unitOfWork.LivroRepository.BulkUpdate(livros);
        watch.Stop();
        Console.WriteLine($"Método utilizado: BulkUpdate\nA operação durou: {watch.Elapsed.TotalSeconds}");
        Console.WriteLine($"Quantiade de livros atualizados: {livros.Count}");
        Console.ReadKey();
    }
    
    public void SimularUpdateRange()
    {
        var livros = _unitOfWork.LivroRepository.Get().ToList();

        livros.ForEach(x => x.Titulo = $"{x.Titulo} - atualizado com Update Range");
        
        var watch = System.Diagnostics.Stopwatch.StartNew();
        _unitOfWork.LivroRepository.UpdateRange(livros);
        _unitOfWork.Commit();
        watch.Stop();
        Console.WriteLine($"Método utilizado: UpdateRange\nA operação durou: {watch.Elapsed.TotalSeconds}");
        Console.WriteLine($"Quantiade de livros atualizados: {livros.Count}");
        Console.ReadKey();
    }

    public void SimularExecuteUpdate()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        _unitOfWork.LivroRepository.ExecuteUpdate();
        watch.Stop();
        Console.WriteLine($"Método utilizado: ExecuteUpdate\nA operação durou: {watch.ElapsedMilliseconds}");
        Console.ReadKey();
    }
    #endregion

    #region Utils
    private (List<Livro>, List<string>, int, int) GerarDados()
    {
        var autorId = Guid.NewGuid();
        _unitOfWork.AutorRepository.Add(new Autor {Id = autorId, Nome = "Autor"});
        var editoraId = Guid.NewGuid();
        _unitOfWork.EditoraRepository.Add(new Editora {Id = editoraId, Nome = "Editora"});
        _unitOfWork.Commit();
        
        var isbns = new List<string>();
        var livros = new List<Livro>();
        var registroRepetido = 0;
        var novosRegistros = 0;
        
        
        for (int i = 0; i < 10000; i++)
        {
            var isbn = StringHelpers.GenerateRandomString(5);
            var titulo = StringHelpers.GenerateRandomString(10);
            // var isbnAlreadyAdded = _unitOfWork.LivroRepository.Get(x => x.ISBN == isbn).Any();

            // if (isbnAlreadyAdded)
            // {
            //     registroRepetido++;
            //     continue;
            // }
            
            livros.Add(new Livro()
            {
                Id = Guid.NewGuid(),
                Titulo = titulo,
                AnoPublicacao = DateTime.Now.Year,
                ISBN = isbn,
                AutorId = autorId,
                EditoraId = editoraId
            });

            novosRegistros++;
        }

        var existingIsbns = _unitOfWork.LivroRepository
            .GetExistingISBN(livros.Select(x => x.ISBN).ToList());

        if (existingIsbns.Count > 0)
        {
            var duplicatedLivrosIsbns = livros.Where(x => existingIsbns.Contains(x.ISBN)).ToList();

            foreach (var livro in duplicatedLivrosIsbns)
            {
                livro.ISBN = $"{livro.ISBN}1";
                registroRepetido++;
            }
        }
        
        return (livros, isbns, registroRepetido, novosRegistros);
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
    #endregion
    
}