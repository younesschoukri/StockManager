using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class DepositRepository : Repository<Deposit>, IDepositRepository
    {
        public DepositRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}