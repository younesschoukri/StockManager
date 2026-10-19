using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class SupplierInformationRepository : Repository<SupplierInformation>, ISupplierInformationRepository
    {
        public SupplierInformationRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}