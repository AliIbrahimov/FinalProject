using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Abstracts;
using FinalProjectWithRepositoryDesignPattern.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;

public class EFBaseRepository<T> : IBaseRepository<T> where T : class, new()
{
    private readonly AppDbContext _context;

    public EFBaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T t)
    {
        await _context.Set<T>().AddAsync(t);
    }

    public void Delete(T t)
    {
        _context.Set<T>().Remove(t);
    }

    public void Edit(T t)
    {
        _context.Set<T>().Update(t);
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null, params string[] includes)
    {
        IQueryable<T> query = GetQuery(includes);
        return exp is null
            ? await query.ToListAsync()
            : await query.Where(exp).ToListAsync();

    }

    private IQueryable<T> GetQuery(string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes is not null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }

        return query;
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> exp, params string[] includes)
    {
        IQueryable<T> query = GetQuery(includes);
        return await query.Where(exp).FirstOrDefaultAsync();
    }

    public async Task<bool> IsExist(Expression<Func<T, bool>> exp)
    {
        return await _context.Set<T>().AnyAsync(exp);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync(params string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
        {
            foreach (var item in includes)
            {

                query = query.Include(item);
            }
        }
        return await query.ToListAsync();
    }

    public async Task<List<T>> GetAllPaginatedAsync(int page, int size, Expression<Func<T, bool>> exp = null, params string[] includes)
    {
        IQueryable<T> query = GetQuery(includes);
        return exp is null
            ? await query.Skip((page-1)*size).Take(size).ToListAsync()
            :await query.Where(exp).Skip((page-1)*size).Take(size).ToListAsync();
    }
}
