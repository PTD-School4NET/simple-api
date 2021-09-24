using ShoppingCart.Models;
using System;
using System.Threading.Tasks;

namespace SchoolOf.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepo<T>() where T : BaseDbModel;

        Task<bool> SaveAsync();
    }
}
