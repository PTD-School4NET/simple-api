using SchoolOf.Data.Abstractions;
using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public IRepository<T> GetRepo<T>() where T : BaseDbModel
        {
            return new Repository<T>(this._databaseContext);
        }

        public async Task<bool> SaveAsync()
        {
            return await this._databaseContext.SaveChangesAsync() > 0;
        }
    }
}
