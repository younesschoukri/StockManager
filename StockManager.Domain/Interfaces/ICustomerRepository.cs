using StockManager.Domain.Entities;

namespace StockManager.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetByName(string name);
    }
}