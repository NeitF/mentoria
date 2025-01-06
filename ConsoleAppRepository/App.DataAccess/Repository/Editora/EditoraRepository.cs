using DataAccess.Context;
using DataAccess.Domain;
using DataAccess.Repository;

namespace DataAccess.Repository.RepositoryEditora;

public class EditoraRepository : Repository<Editora>, IEditoraRepository
{
    private ApplicationDbContext _context;
    
    public EditoraRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public Editora GetEditoraPorNome(string nome)
    {
        return Get().Single(x => x.Nome.ToLower().Equals(nome.ToLower()));
    }
}