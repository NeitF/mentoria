using DataAccess.Domain;
using DataAccess.Repository.RepositoryAutor;

namespace DataAccess.Repository;

public interface IUnityOfWork : IDisposable
{
    IAutorRepository AutorRepository { get; }
    IEditoraRepository EditoraRepository { get; }
    ILivroRepository LivroRepository { get; }
    void Commit();
}