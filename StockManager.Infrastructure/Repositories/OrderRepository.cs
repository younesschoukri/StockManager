using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}