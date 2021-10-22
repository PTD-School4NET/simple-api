using ShoppingCart.Models;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepo<T>() where T : BaseDbModel;

        Task<bool> SaveAsync();
    }
}
