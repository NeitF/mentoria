using DataAccess.Domain;
using DataAccess.Repository;

public interface IEditoraRepository : IRepository<Editora>
{
    Editora GetEditoraPorNome(string nome);
}