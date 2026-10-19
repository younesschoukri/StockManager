using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StockManagerDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Customer> GetByName(string name) => context.Customers.Where(customer => customer.Name.Contains(name));
    }
}