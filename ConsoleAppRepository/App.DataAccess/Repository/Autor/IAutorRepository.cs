using DataAccess.Domain;
using DataAccess.Repository;

namespace DataAccess.Repository.RepositoryAutor;

public interface IAutorRepository : IRepository<Autor>
{
    Autor GetAutorPorNome(string nome);
}