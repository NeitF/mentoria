using DataAccess.Context;
using DataAccess.Domain;
using DataAccess.Repository.RepositoryAutor;
using DataAccess.Repository.RepositoryEditora;
using DataAccess.Repository.RepositoryLivro;

namespace DataAccess.Repository;

public class UnitOfWork : IUnityOfWork
{
    public ApplicationDbContext _context;
    
    private IAutorRepository _autorRepository;
    private IEditoraRepository _editoraRepository;
    private ILivroRepository _livroRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public UnitOfWork()
    {
        _context = new ApplicationDbContext();
    }

    #region Repositories
    public IAutorRepository AutorRepository => _autorRepository ??= new AutorRepository(_context);
    public IEditoraRepository EditoraRepository => _editoraRepository ??= new EditoraRepository(_context);
    public ILivroRepository LivroRepository => _livroRepository ??= new LivroRepository(_context);
    #endregion

    public void Commit()
    {
        _context.SaveChanges();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public void LimparBanco()
    {
        _context.BulkDelete(_context.Set<Livro>());
        _context.BulkDelete(_context.Set<Editora>());
        _context.BulkDelete(_context.Set<Autor>());
    }
}