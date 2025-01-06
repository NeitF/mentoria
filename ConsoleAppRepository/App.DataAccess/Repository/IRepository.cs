using System.Linq.Expressions;

namespace DataAccess.Repository;

public interface IRepository<T> where T : class
{
    IQueryable<T> Get();
    IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    T GetById(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}