using FinalProjectWithRepositoryDesignPattern.Models;
using System.Linq.Expressions;

namespace FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Abstracts;

public interface IBaseRepository<T>
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null, params string[] includes);
    Task<List<T>> GetAllAsync(params string[] includes);
    Task<List<T>> GetAllPaginatedAsync(int page, int size, Expression<Func<T, bool>> exp = null, params string[] includes);
    Task<T> GetByIdAsync(Expression<Func<T, bool>> exp, params string[] includes);
    Task<bool> IsExist(Expression<Func<T, bool>> exp);
    Task CreateAsync(T t);
    void Edit(T t);
    void Delete(T t);
    Task SaveAsync();
}
