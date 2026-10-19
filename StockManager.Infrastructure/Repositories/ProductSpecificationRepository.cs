using StockManager.Domain.Entities;
using StockManager.Domain.Interfaces;
using StockManager.Infrastructure.Persistence;

namespace StockManager.Infrastructure.Repositories
{
    public class ProductSpecificationRepository : Repository<ProductSpecification>, IProductSpecificationRepository
    {
        public ProductSpecificationRepository(StockManagerDbContext context)
            : base(context)
        {
        }
    }
}