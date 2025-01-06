using DataAccess.Context;
using DataAccess.Domain;

namespace DataAccess.Repository.RepositoryAutor;

public class AutorRepository : Repository<Autor>, IAutorRepository
{
    private ApplicationDbContext _context;

    public AutorRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Autor GetAutorPorNome(string nome)
    {
        return Get().Single(x => x.Nome.ToLower().Equals(nome.ToLower()));
    }
    
}