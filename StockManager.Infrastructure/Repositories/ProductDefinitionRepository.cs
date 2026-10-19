using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class ProductDefinitionRepository : Repository<ProductDefinition>, IProductDefinitionRepository
    {
        public ProductDefinitionRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}