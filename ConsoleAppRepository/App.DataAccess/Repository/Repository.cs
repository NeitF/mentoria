using System.Linq.Expressions;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
    
    public IQueryable<T> Get()
    {
        return _context.Set<T>();
    }

    public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate).ToList();
    }

    public T GetById(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().SingleOrDefault(predicate);
    }

    
}