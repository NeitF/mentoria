using System.Linq.Expressions;
using DataAccess.Context;
using DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.RepositoryLivro;

public class LivroRepository : Repository<Livro>, ILivroRepository
{
    private ApplicationDbContext _context;
    
    public LivroRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    #region Get
    public Livro GetLivroPorTitulo(string titulo)
    {
        return Get().Single(x => x.Titulo.ToLower().Equals(titulo.ToLower()));
    }

    public List<string> GetExistingISBN(List<string> isbns)
    {
        // SOLUÇÃO PARA BANCO ORACLE, POIS O ORACLE SÓ SUPORTA UM CONTAINS COM NO MÁXIMO 1000 REGISTROS
        // var ISBNSplited = SplitList(isbns, 1000);
        // var existentISBN = new List<string>();
        //
        // foreach (var isbn in ISBNSplited)
        // {
        //     existentISBN.AddRange(_context.Livros.Where(x => isbns.Contains(x.ISBN)).Select(x => x.ISBN).ToList());    
        // }
        //
        // return existentISBN;
        
        return _context.Livros.Where(x => isbns.Contains(x.ISBN)).Select(x => x.ISBN).ToList();
    }
    #endregion
    
    public static List<List<T>> SplitList<T>(List<T> lista, int tamanhoMaximo)
    {
        var listaDividida = new List<List<T>>();

        for (var i = 0; i < lista.Count; i += tamanhoMaximo)
        {
            listaDividida.Add(lista.GetRange(i, Math.Min(tamanhoMaximo, lista.Count - i)));
        }

        return listaDividida;
    }
 
    

    #region Delete
    public void BulkDelete()
    {
        IQueryable<Livro> livros = _context.Set<Livro>();
        _context.BulkDelete(livros);
    }

    public void RemoveRange()
    {
        IQueryable<Livro> livros = _context.Set<Livro>();
        _context.RemoveRange(livros);
    }
    #endregion

    #region Add
    public void BulkInsert(List<Livro> livros)
    {
        _context.BulkInsert(livros);
    }

    public void AddRange(List<Livro> livros)
    {
        _context.AddRange(livros);
    }
    #endregion

    #region Update
    public void BulkUpdate(List<Livro> livros)
    {
        _context.BulkUpdate(livros, operations =>
        {
            operations.BatchSize = 1000;
            operations.IgnoreOnUpdateExpression = x => new { x.EditoraId };
        });
    }

    public void UpdateRange(List<Livro> livros)
    {
        _context.UpdateRange(livros);
    }

    public void ExecuteUpdate()
    {
        _context.Livros
            .ExecuteUpdateAsync(x => x.SetProperty(x => x.Titulo, "Atualizado com ExecuteUpdate"));
    }
    #endregion
    
}