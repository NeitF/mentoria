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
    #endregion

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
        _context.BulkUpdate(livros);
    }

    public void UpdateRange(List<Livro> livros)
    {
        _context.UpdateRange(livros);
    }
    #endregion
    
}