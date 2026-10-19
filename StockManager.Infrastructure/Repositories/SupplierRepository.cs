using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}