using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Abstractions
{
    public interface IRepository<T> where T : BaseDbModel
    {
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);
        Task<bool> DeleteAsync(long id);
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> searchCriteria, int skip, int take);
    }
}