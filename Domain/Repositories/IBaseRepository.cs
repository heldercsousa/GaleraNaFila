﻿using System.Linq.Expressions;

namespace MyKaraoke.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}
