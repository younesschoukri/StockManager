using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class CustomerBankCheckRepository : Repository<CustomerBankCheck>, ICustomerBankCheckRepository
    {
        public CustomerBankCheckRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}