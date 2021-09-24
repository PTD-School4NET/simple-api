using Microsoft.EntityFrameworkCore;
using SchoolOf.Data.Abstractions;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public class Repository<T> : IRepository<T> where T : BaseDbModel
    {
        private readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext databaseContext)
        {
            this._dbSet = databaseContext.Set<T>();
        }

        public async Task<T> AddAsync(T model)
        {
            return await Task.FromResult(this._dbSet.Add(model).Entity); 
        }

        public async Task<bool> DeleteAsync(T model)
        {
            return await Task.FromResult(this._dbSet.Remove(model) != null);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await this.GetByIdAsync(id);
            return this._dbSet.Remove(entity) != null; 
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> searchCriteria)
        {
            return await this._dbSet.Where(searchCriteria).ToListAsync();
        } 

        public async Task<T> UpdateAsync(T model)
        {
            return await Task.FromResult(this._dbSet.Update(model).Entity);
        }
    }
}
