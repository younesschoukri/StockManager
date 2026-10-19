using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class CustomerInformationRepository : Repository<CustomerInformation>, ICustomerInformationRepository
    {
        public CustomerInformationRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}