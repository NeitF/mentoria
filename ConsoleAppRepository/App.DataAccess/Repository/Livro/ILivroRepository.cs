using System.Linq.Expressions;
using DataAccess.Domain;
using DataAccess.Repository;

public interface ILivroRepository : IRepository<Livro>
{
    void BulkInsert(List<Livro> livros);
    void AddRange(List<Livro> livros);
    void BulkUpdate(List<Livro> livros);
    void UpdateRange(List<Livro> livros);
    void ExecuteUpdate();
    void BulkDelete();
    void RemoveRange();
    Livro GetLivroPorTitulo(string nome);
}