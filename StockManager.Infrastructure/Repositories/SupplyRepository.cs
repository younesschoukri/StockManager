using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class SupplyRepository : Repository<Supply>, ISupplyRepository
    {
        public SupplyRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}