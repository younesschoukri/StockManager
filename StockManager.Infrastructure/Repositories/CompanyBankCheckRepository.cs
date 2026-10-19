using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class CompanyBankCheckRepository : Repository<CompanyBankCheck>, ICompanyBankCheckRepository
    {
        public CompanyBankCheckRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}