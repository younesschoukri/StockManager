using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}